using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{

  
    public void Start()
    {
        
      SoundManager.Instance.PlaySound2D("MenuSound");
      
    }


    
    public void OnClickPlay()
    {

     if (LoadingScreenManager.Instance != null)
    {
        LoadingScreenManager.Instance.SwitchToScene("World");
    }
    else
    {
        Debug.LogError("LoadingScreenManager.Instance is null!");
    }

      SoundManager.Instance.StopSound2D("MenuSound");
      SoundManager.Instance.PlaySound2D("LevelSound");

    }


    public void Settings(){
      //  levelManager.Instance.LoadScene("Settings");
    }
    public void QuitGame()
    {
     
        Application.Quit();
    }
}