using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public Image[] questItems; // uma imagem para cada moeda
    public Color completedColor;
    public Color incompleteColor;

    public GameObject[] barriers; // uma barreira para cada moeda
    public GameObject levelCompleteImg;

    private int collectedCoins = 0;
    private int totalCoins;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("QuestItem").Length;

        // Inicializa todas as imagens da missão como incompletas
        foreach (var img in questItems)
        {
            img.color = incompleteColor;
        }

        // Garante que a imagem de Level Complete não apareça antes da hora
        levelCompleteImg.SetActive(false);

        if (barriers.Length != totalCoins || questItems.Length != totalCoins)
        {
            Debug.LogWarning("Número de questItems ou barreiras diferente do número de moedas!");
        }
    }


    public void CollectCoin(GameObject coin)
    {
        // Atualiza a missão correspondente
        if (collectedCoins < questItems.Length)
        {
            questItems[collectedCoins].color = completedColor;
        }

        // Desativa a barreira correspondente
        if (collectedCoins < barriers.Length)
        {
            barriers[collectedCoins].SetActive(false);
            Debug.Log("Barreira desativada: " + barriers[collectedCoins].name);
        }

        collectedCoins++;
        Destroy(coin);

        if (collectedCoins >= totalCoins)
        {
            levelCompleteImg.SetActive(true);
            Debug.Log("Você venceu!");
        }
    }
}
