using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour 
{
    [SerializeField] private Transform barrel;  // Ponto de origem do disparo
    [SerializeField] private float fireRate;  // Tempo entre disparos
    [SerializeField] private GameObject bullet;  // Prefab da bala
    private float fireTimer;  // Temporizador para controlar o tempo entre disparos

    void Start()
    {
        fireTimer = 0f;  // Inicializa o temporizador
    }

    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        // Verifica se o botão do mouse foi clicado e se é possível disparar
        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, barrel.position, barrel.rotation);  // Instancia a bala no ponto de origem
        fireTimer = Time.time + fireRate;  // Atualiza o temporizador de disparo
    }

    private bool CanShoot()
    {
        return Time.time > fireTimer;  // Verifica se o tempo atual é maior que o tempo de disparo
    }
}
