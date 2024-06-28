using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] Pontos_PullUp;
    public GameObject[] Pontos_PullDown;
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

    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player");
        Pontos_PullDown = GameObject.FindGameObjectsWithTag("PontoDown");
        Pontos_PullUp = GameObject.FindGameObjectsWithTag("PontoUp");
        RespawnPoint = GameObject.FindGameObjectWithTag("respawnPoint");

        if (RespawnPoint != null)
        {
            SetRespawnPoint(RespawnPoint.transform.position);
        }
        else
        {
            Debug.LogError("Respawn point not found. Please ensure a GameObject with tag 'respawnPoint' exists in the scene.");
        }

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DeathTrigger();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
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
