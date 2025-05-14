using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    float nextSpawnTime;

    public GameObject enemy;
    public Transform[] spawnPoints;
    public int maxEnemies;

    private int enemiesSpawned = 0; // contador de inimigos já spawnados

    void Update()
    {
        if (Time.time > nextSpawnTime && enemiesSpawned < maxEnemies)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;

            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);

            enemiesSpawned++; // incrementa o contador
            Debug.Log("Inimigos Spawnados: " + enemiesSpawned);
        }
    }
}
