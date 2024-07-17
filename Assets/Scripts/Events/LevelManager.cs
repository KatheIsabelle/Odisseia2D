using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {            
        if (other.CompareTag("Portal"))
        {
            Debug.Log("Player touched the portal");
            Invoke(nameof(NextLevel), 1f);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        LoadingScreenManager.Instance.SwitchToScene(sceneName);
    }
    
    void NextLevel()
    {
        string nextSceneName = "world"; 
        LoadSceneByName(nextSceneName);
    }
}
