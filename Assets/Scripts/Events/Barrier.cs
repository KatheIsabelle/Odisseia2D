using UnityEngine;

public class Barrier : MonoBehaviour
{
     private GameObject player;
     private GameObject barrierObject;

    void Start()
    {
        // Inicialização, se necessário
        player = GameObject.FindGameObjectWithTag("Player");
        barrierObject = GameObject.FindGameObjectWithTag("Barries");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf && other.CompareTag("Player"))
        {
            Debug.Log("Jogador tocou em uma barreira ativa: " + gameObject.name);
            float distance = Vector3.Distance(player.transform.position, barrierObject.transform.position);
            Debug.Log($"Distância da barreira {barrierObject.name}: {distance}");
            HealthManager.Instance.TriggerDeathAndRespawn();
        }
    }
    
}
