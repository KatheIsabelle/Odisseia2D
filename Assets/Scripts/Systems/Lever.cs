using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject player;
    public float proximityDistance = 1.8f;
    public GameObject[] Alavancas;
    public GameObject[] Pontos_PullUp;
    public GameObject[] Pontos_PullDown;
    public GameObject[] Light;
    public Dictionary<string, bool> pontosAtivos = new Dictionary<string, bool>();
    public GameObject img;

    void Start()
    {
        InicializarComponentes();
        InicializarEstadosPontos();
        //img.SetActive(false);
    }

    void Update()
    {
        IsPlayerNearTarget();
    }

    private void InicializarComponentes()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Alavancas = GameObject.FindGameObjectsWithTag("Alavanca");
        Pontos_PullUp = GameObject.FindGameObjectsWithTag("PontoUp");
        Pontos_PullDown = GameObject.FindGameObjectsWithTag("PontoDown");
        Light = GameObject.FindGameObjectsWithTag("light");
    }

    private void InicializarEstadosPontos()
    {
        foreach (GameObject ponto in Pontos_PullUp)
        {
            pontosAtivos[ponto.name] = false;
        }
        foreach (GameObject ponto in Pontos_PullDown)
        {
            pontosAtivos[ponto.name] = true;
        }
    }

    public bool IsPlayerNearTarget()
    {
        if (!ComponentesValidos())
        {
            Debug.LogWarning("Jogador, Alavancas ou Pontos não estão configurados corretamente.");
            return false;
        }

        foreach (GameObject alavanca in Alavancas)
        {  

            if (VerificarProximidade(alavanca))
            {   
                img.SetActive(true);
                SoundManager.Instance.PlaySound2D("TipSound");

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ProcessarAlavanca(alavanca);
                }
                return true;
            }
            else
            {
                img.SetActive(false);
            }
        }

        return false;
    }


    private bool ComponentesValidos()
    {
        return player != null && Alavancas != null && Pontos_PullUp != null && Pontos_PullDown != null;
    }


    private bool VerificarProximidade(GameObject alavanca)
    {
        if (alavanca != null && alavanca.activeInHierarchy)
        {   
            float distance = Vector3.Distance(player.transform.position, alavanca.transform.position);           
            return distance <= proximityDistance;
            
            
        }
        return false;
    }


    private void ProcessarAlavanca(GameObject alavanca)
    {
        string nomeAlavanca = alavanca.name;
        string nomePontoUp = nomeAlavanca.Replace("Alavanca_", "") + "_up";
        string nomePontoDown = nomeAlavanca.Replace("Alavanca_", "") + "_down";
        GameObject pontoUp = System.Array.Find(Pontos_PullUp, p => p.name == nomePontoUp);
        GameObject pontoDown = System.Array.Find(Pontos_PullDown, p => p.name == nomePontoDown);

        if (pontoUp != null && pontoDown != null)
        {
            AlternarEstadoPonto(nomePontoUp, pontoUp);
            AlternarEstadoPonto(nomePontoDown, pontoDown);

            string nomePainel = nomePontoUp.Replace("_up", "");
            AtualizarStatus(alavanca, nomePainel, pontosAtivos[nomePontoUp]);
        }
    }

    private void AlternarEstadoPonto(string nomePonto, GameObject ponto)
    {
        pontosAtivos[nomePonto] = !pontosAtivos[nomePonto];
        ponto.SetActive(pontosAtivos[nomePonto]);
    }


    private void AtualizarStatus(GameObject alavanca, string nomePainel, bool estadoPontoUp)
    {
        int valor = estadoPontoUp ? 1 : 0; 
        Status.Instance.AlterarValorDoPonto(nomePainel, valor);

        // Pega o Animator da alavanca processada
        Animator alavancaAnimator = alavanca.GetComponent<Animator>();

        if (alavancaAnimator != null)
        {
            // Atualiza o parâmetro Direction no Animator
            if (estadoPontoUp)
            {
                alavancaAnimator.SetInteger("Direction", 1); // Esquerda (estado PullUp ativo)
            }
            else
            {
                alavancaAnimator.SetInteger("Direction", -1); // Direita (estado PullDown ativo)
            }

            // Atualiza estados visuais ou comportamentais dos pontos
            AtualizarPontos(alavanca, estadoPontoUp);
            AtualizarLuzes(nomePainel, estadoPontoUp);
        }
        else
        {
            Debug.LogWarning($"Animator não encontrado na alavanca: {alavanca.name}");
        }

        Status.Instance.AtualizarTextos();
    }


    private void AtualizarPontos(GameObject alavanca, bool estadoPontoUp)
    {
        // Define os nomes esperados para os pontos relacionados a esta alavanca
        string nomePontoUp = alavanca.name.Replace("Alavanca_", "") + "_up";
        string nomePontoDown = alavanca.name.Replace("Alavanca_", "") + "_down";

        // Busca os pontos associados
        GameObject pontoUp = System.Array.Find(Pontos_PullUp, p => p.name == nomePontoUp);
        GameObject pontoDown = System.Array.Find(Pontos_PullDown, p => p.name == nomePontoDown);

        // Atualiza os estados visuais ou de ativação dos pontos
        if (pontoUp != null)
        {
            pontoUp.SetActive(estadoPontoUp); // Ativa/Desativa PullUp
        }

        if (pontoDown != null)
        {
            pontoDown.SetActive(!estadoPontoUp); // Ativa/Desativa PullDown
        }
    }


    private void AtualizarLuzes(string nomePainel, bool estadoPontoUp)
    {
        // Define o nome esperado para a luz associada ao painel
        string nomeLuz = nomePainel.Replace("_up", "").Replace("_down", "");

        // Busca todas as luzes associadas ao painel
        GameObject[] luzes = GameObject.FindGameObjectsWithTag("light");

        // Encontra a luz que corresponde ao nome do painel (por exemplo, Light_A)
        GameObject luz = System.Array.Find(luzes, l => l.name.Contains(nomeLuz));

        if (luz != null)
        {
            // Pega o Animator da luz
            Animator luzAnimator = luz.GetComponent<Animator>();

            if (luzAnimator != null)
            {
                // Atualiza o parâmetro ColorState no Animator
                luzAnimator.SetInteger("ColorState", estadoPontoUp ? 1 : 0); // 0 = Vermelho, 1 = Verde
            }
            else
            {
                Debug.LogWarning($"Animator não encontrado na luz: {luz.name}");
            }
        }
        else
        {
            Debug.LogWarning($"Luz associada ao painel {nomePainel} não encontrada.");
        }
    }
}
