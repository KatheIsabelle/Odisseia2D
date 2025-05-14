using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;
    public GameObject LoadingScreenObject;
    public Slider ProgressBar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchToScene(string sceneName)
    {
        if (LoadingScreenObject != null)
        {
            LoadingScreenObject.SetActive(true);
        }

        if (ProgressBar != null)
        {
            ProgressBar.value = 0;
        }

        StartCoroutine(SwitchToSceneAsync(sceneName));
    }

    IEnumerator SwitchToSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // Impede que a cena mude antes do loading estar completo

        while (asyncLoad.progress < 0.9f) // Carregando até 90%
        {
            if (ProgressBar != null)
            {
                ProgressBar.value = asyncLoad.progress / 0.9f; // Normaliza o progresso para a barra chegar a 1.0
            }
            yield return null;
        }

        // Aguarda um pequeno tempo extra e depois ativa a cena
        yield return new WaitForSeconds(0.8f);
        asyncLoad.allowSceneActivation = true;

        // Aguarda mais um pouco para esconder a tela de loading após a cena ser carregada
        yield return new WaitForSeconds(0.6f);
        
        if (LoadingScreenObject != null)
        {
            LoadingScreenObject.SetActive(false);
        }
    }
}
