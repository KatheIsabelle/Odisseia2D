using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public GameObject player;


    void Start(){
        player = GameObject.Find("Player");
    }

    void  OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Portal")){
            Invoke(nameof(NextLevel), 1f);
        }
        
    }


    void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //index fixo para cada portal 

    }
    
}