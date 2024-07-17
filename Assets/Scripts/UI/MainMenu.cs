using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters;

public class MainMenu : MonoBehaviour
{
    public string nextSceneName;
    public void Start()
    {
        SoundManager.Instance.PlaySound2D("LevelSound");
    }

    public void OnClickPlay()
    {
        if (LoadingScreenManager.Instance != null)
        {
            LoadingScreenManager.Instance.SwitchToScene(nextSceneName);
            //SoundManager.Instance.StopSound2D("MenuSound");
            SoundManager.Instance.PlaySound2D("LevelSound");
        }
        else
        {
            Debug.LogError("LoadingScreenManager.Instance is null!");
        }
    }

    public void Settings()
    {
        // levelManager.Instance.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
          //SoundManager.Instance.StopSound2D("MenuSound");
          SoundManager.Instance.PlaySound2D("LevelSound");
        }
    }

    
}
