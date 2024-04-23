using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public GameObject pontoDown;
    public GameObject pontoUp;
    public int maxHealth;
    public int currentHealth;
    public Vector3 respawnPoint;
    private GameObject player;
    public float proximityDistance = 2f;

    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetRespawnPoint(transform.position);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DeathTrigger();
    }

    public void DeathTrigger()
    {
        float distance = Vector3.Distance(player.transform.position, pontoDown.transform.position);
        if (distance <= proximityDistance && pontoDown.activeSelf)
        {
            currentHealth = 0;
            animator.SetTrigger("IsDead");
            Debug.Log("Player died");
            StartCoroutine(Respawn());
        }
       
    }

    private void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        if (player != null)
        {
            animator.SetTrigger("IsRespawn");
            player.transform.position = respawnPoint;
            currentHealth = maxHealth;
        }
    }
}
