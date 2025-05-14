using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shot : MonoBehaviour 
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float shotSpeed;
    public int damage;

    void Start()
    {
        Destroy(gameObject, lifeTime);

    }

    void Update()
    {
        transform.Translate(Vector2.right * shotSpeed * Time.deltaTime);

    }





}