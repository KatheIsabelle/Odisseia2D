/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    public Color incompleteColor;
    public GameObject LevelCompleteImg;

    private int collectedCoins = 0;
    private int totalCoins;

    public GameObject[] Barries;

    void Start()
    {
        // Encontra todas as barreiras
        Barries = GameObject.FindGameObjectsWithTag("Barries");

        // Encontra todas as moedas na cena com a mesma tag do script
        totalCoins = GameObject.FindGameObjectsWithTag("QuestItem").Length;

        // Define a cor inicial do item de quest
        questItem.color = incompleteColor;
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

            // Desativa a barreira correspondente, se houver
            if (collectedCoins <= Barries.Length)
            {
                GameObject barrierToDisable = Barries[collectedCoins - 1];
                if (barrierToDisable != null && barrierToDisable.activeInHierarchy)
                {
                    barrierToDisable.SetActive(false);
                    Debug.Log("Barrier desativada: " + barrierToDisable.name);
                }
            }

            Destroy(gameObject); // Destroi a moeda após ser coletada
        }
    }

    void FinishQuest()
    {
        questItem.color = completedColor;
    }

    private void CompleteLevel()
    {
        if (collectedCoins >= totalCoins)
        {
            LevelCompleteImg.SetActive(true);
            Debug.Log("You win!");
        }
    }
}
*/