using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    public Color incompleteColor;
    public int coins;

    private int collectedCoins;
    public GameObject[] Barriers; 

    void Start()
    {
        Barriers = GameObject.FindGameObjectsWithTag("Barriers");
        questItem.color = incompleteColor;
        collectedCoins = 0;
    }
    
    void Update()
    {
        CompleteLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishQuest();
            collectedCoins++;
            Debug.Log("Coins collected: " + collectedCoins);
            Destroy(gameObject);

            foreach (GameObject Barrier in Barriers)
            {
                if (Barrier != null && Barrier.activeInHierarchy)
                {
                    Barrier.SetActive(false);
                    Debug.Log("Barrier desativada");
                }
            }
        }
    }

    void FinishQuest()
    {
        questItem.color = completedColor;
    }

    private void CompleteLevel()
    {
        if (collectedCoins >= 3)
        {
            Debug.Log("You win!");
        }
    }
}
