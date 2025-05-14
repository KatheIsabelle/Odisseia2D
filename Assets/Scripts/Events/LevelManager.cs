using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    public GameObject[] portais;

    void Start()
    {
        
        portais = new GameObject[5];
        portais[0] = GameObject.FindGameObjectWithTag("Inversor");
        portais[1] = GameObject.FindGameObjectWithTag("NAND");
        portais[2] = GameObject.FindGameObjectWithTag("Complexa");
        portais[3] = GameObject.FindGameObjectWithTag("AOI");
        portais[4] = GameObject.FindGameObjectWithTag("World");

        
    }

    // Colisão player > portal
    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player entrou no portal");
            NextLevel(other);
        }
    }


    public void LoadSceneByName(string sceneName) 
    {
        if (LoadingScreenManager.Instance != null)
        {   
            // Usa o LoadingScreenManager para carregar a cena
            LoadingScreenManager.Instance.SwitchToScene(sceneName);
        }
        else
        {
            Debug.LogError("LoadingScreenManager não encontrado!");
        }
    }


    public void NextLevel(Collider2D player)
    {   
        // Verifica qual portal o player entrou e carrega a cena correspondente
        foreach (GameObject portal in portais)
        {
            if (portal != null) 
            {
                Collider2D portalCollider = portal.GetComponent<Collider2D>();
                
                if (portalCollider != null && portalCollider.IsTouching(player)) 
                {
                    string nextSceneName = "";

                    
                    if (portal.CompareTag("Inversor"))
                    {
                        nextSceneName = "Inversor";
                        Debug.Log("Carregando Inversor");
                    }
                    else if (portal.CompareTag("NAND"))
                    {
                        nextSceneName = "NAND";
                        Debug.Log("Carregando NAND");
                    }
                    else if (portal.CompareTag("Complexa"))
                    {
                        nextSceneName = "COMPLEXA"; 
                        Debug.Log("Carregando COMPLEXA");
                    }
                    else if (portal.CompareTag("AOI"))
                    {
                        nextSceneName = "AOI";
                        Debug.Log("Carregando AOI");
                    }
                    else if (portal.CompareTag("World"))
                    {
                        nextSceneName = "World";
                        Debug.Log("Carregando World"); 
                    }

                    // Carrega a cena com o nome atribuído
                    if (!string.IsNullOrEmpty(nextSceneName))
                    {
                        LoadSceneByName(nextSceneName);
                    }
                    else
                    {
                        Debug.LogError("Não foi possível determinar a cena do portal.");
                    }

                    break; 
                }
                else
                {
                    Debug.LogWarning("Portal sem Collider2D ou o Player não está tocando o portal.");
                }
            }
            else
            {
                Debug.LogWarning("Portal não encontrado.");
            }
        }
    }
}
