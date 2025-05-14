using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    Transform player;
    public int health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

    }


   void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag ("Shot"))
        {
            TakeDamage(other.GetComponent<Shot>().damage);
        
        }

        if (other.CompareTag("Player"))
        {   
            HealthManager healthManager = other.GetComponent<HealthManager>();
            healthManager.SetHealth(healthManager.currentHealth - healthManager.damage);
            healthManager.TriggerDeathAndRespawn2();

        }
   }


   void TakeDamage(int damageAmount)
   {
       health -= damageAmount;
       if (health <= 0)
       {
           Destroy(gameObject);
       }
   }

}
