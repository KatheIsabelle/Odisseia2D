using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] Pontos_PullUp;
    public GameObject[] Pontos_PullDown;
    public GameObject[] Barries;
    public int maxHealth = 100;
    public int currentHealth;
    private Vector3 respawnPoint;
    private GameObject RespawnPoint;
    private GameObject player;
    public float proximityDistance = 1.8f;
    private Animator animator;
    public Slider slider;
    public HealthBar healthBar;
    public static HealthManager Instance;
    public int damage;

    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player");
        Barries = GameObject.FindGameObjectsWithTag("Barries");
        Pontos_PullDown = GameObject.FindGameObjectsWithTag("PontoDown");
        Pontos_PullUp = GameObject.FindGameObjectsWithTag("PontoUp");
        RespawnPoint = GameObject.FindGameObjectWithTag("respawnPoint");

        if (RespawnPoint != null)
        {
            SetRespawnPoint(RespawnPoint.transform.position);
        }
        else
        {
            Debug.LogError("Respawn point not found.");
        }

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DeathTrigger();
        //DeathTrigger2();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        slider.value = health;
        healthBar.SetHealth(currentHealth);
    }   

    public void DeathTrigger()
    {
        foreach (GameObject ponto in Pontos_PullUp)
        {
            if (ponto != null && ponto.activeInHierarchy)
            {
                float distance = Vector3.Distance(player.transform.position, ponto.transform.position);
                if (distance <= proximityDistance)
                {
                    TriggerDeathAndRespawn();
                }
            }
        }

        foreach (GameObject ponto in Pontos_PullDown)
        {
            if (ponto != null && ponto.activeInHierarchy)
            {
                float distance = Vector3.Distance(player.transform.position, ponto.transform.position);
                if (distance <= proximityDistance)
                {
                    TriggerDeathAndRespawn();
                }
            }
        }
    }

    public void TriggerDeathAndRespawn2()
    {
        animator.SetTrigger("isDamaged");
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {   
            currentHealth = 0;
            animator.SetTrigger("IsDead");
            healthBar.SetHealth(currentHealth);
            StartCoroutine(Respawn());
        }
    }



    public void TriggerDeathAndRespawn()
    {
        currentHealth = 50;
        animator.SetTrigger("IsDead");
        StartCoroutine(Respawn());
        healthBar.SetHealth(currentHealth);
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
            player.transform.position = respawnPoint;
            animator.SetTrigger("IsRespawn");
            animator.ResetTrigger("IsDead");
            currentHealth = maxHealth;
        }
    }
}
