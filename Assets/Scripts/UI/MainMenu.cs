using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        SoundManager.Instance.PlaySound2D("MenuSound");
    }

    public void OnClickPlay()
    {   
        if (LoadingScreenManager.Instance != null)
        {
            LoadingScreenManager.Instance.SwitchToScene("World");
            SoundManager.Instance.PlaySound2D("LevelSound");
        }
        else
        {
            Debug.LogWarning("LoadingScreenManager.Instance is null! Carregando a cena diretamente...");
            SceneManager.LoadScene("World"); // Carrega a cena diretamente caso o LoadingScreenManager não esteja disponível
        }
    }

    public void OnClickSettings()
    {   
        settingsMenu.SetActive(true);     
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
