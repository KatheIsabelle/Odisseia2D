    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro; 


    public class Lever : MonoBehaviour{
        
        public GameObject player;
        public float proximityDistance = 1.8f;
        public GameObject[] Alavancas;
        public GameObject[] Pontos_PullUp;
        public GameObject [] Pontos_PullDown;
        public GameObject[] Light;
        public static Lever Instance;
        private Animator animator;

        public Dictionary<string, bool> pontosAtivos = new Dictionary<string, bool>();

            
        void Start()
        {
            // Atribuir valor inicial aos arrays, se necessário
            player = GameObject.FindGameObjectWithTag("Player");
            Alavancas = GameObject.FindGameObjectsWithTag("Alavanca");
            Pontos_PullUp = GameObject.FindGameObjectsWithTag("PontoUp");
            Pontos_PullDown = GameObject.FindGameObjectsWithTag("PontoDown");
            
            Light = GameObject.FindGameObjectsWithTag("light");
            animator = GetComponent<Animator>();


              // Inicializar o estado dos pontos como ativos
            foreach (GameObject ponto in Pontos_PullUp)
            {
                pontosAtivos[ponto.name] = true;
            // ponto.SetActive(true);
            }
            foreach (GameObject ponto in Pontos_PullDown)  //percorrer array com tag gameobjects 
            {
                pontosAtivos[ponto.name] = false; 
               // ponto.SetActive(false);  VERIFICA MÉTODO DE ATIVAÇÃO
            }

            
        }

        void Update()
        {
            IsPlayerNearTarget();
        
        }
    

        public bool IsPlayerNearTarget()
        {
            if (player != null && Alavancas != null && Pontos_PullUp != null && Pontos_PullDown != null)
            {
                foreach (GameObject alavanca in Alavancas)
                {
                    if (alavanca != null && alavanca.activeInHierarchy)
                    {
                        float distance = Vector3.Distance(player.transform.position, alavanca.transform.position);
                        if (distance <= proximityDistance)
                        {
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                string nomeAlavanca = alavanca.name;
                                string nomePontoUp = nomeAlavanca.Replace("Alavanca_", "") + "_up";
                                string nomePontoDown = nomeAlavanca.Replace("Alavanca_", "") + "_down";
                                GameObject pontoUp = System.Array.Find(Pontos_PullUp, p => p.name == nomePontoUp);
                                GameObject pontoDown = System.Array.Find(Pontos_PullDown, p => p.name == nomePontoDown);

                                if (pontoUp != null && pontoDown != null)
                                {
                                    //pullup inverte valores e atualiza ativa/desativa
                                    pontosAtivos[nomePontoUp] = !pontosAtivos[nomePontoUp]; 
                                    pontoUp.SetActive(pontosAtivos[nomePontoUp]);

                                    //pulldown inverte valores e atualiza ativa/desativa
                                    pontosAtivos[nomePontoDown] = !pontosAtivos[nomePontoDown];
                                    pontoDown.SetActive(pontosAtivos[nomePontoDown]);

                                    string nomePainel = nomePontoUp.Replace("_up", "");
                                                                    
                                    if (pontosAtivos[nomePontoUp] == true)
                                    {
                                        Status.Instance.AlterarValorDoPonto(nomePainel, 0);
                                    }
                                    else
                                    {
                                        Status.Instance.AlterarValorDoPonto(nomePainel, 1);
                                    }                                                        
                                    
                                    Status.Instance.AtualizarTextos();
                              
                                }

                                if (pontosAtivos[nomePontoUp] == true && pontosAtivos[nomePontoDown] == true){
                                    
                                    animator.SetBool("LightOff", true);

                                }
                                else{

                                    animator.SetBool("LightOn", true);

                                }

                 


                            }
                        
                            return true;
                        }
                    }
                }
            
                return false;
            }
            else
            {
                Debug.LogWarning("Jogador, Alavancas ou Pontos_PullUp não estão definidos!");
                Debug.LogWarning("Jogador, Alavancas ou Pontos_PullDown não estão definidos!");
                return false;
            }
        }
    }
