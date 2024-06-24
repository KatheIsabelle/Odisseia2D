using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shot : MonoBehaviour {

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private Vector3 screenPoint;
    public float lifeTime = 2f;


    public float force;

    private void Start(){
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = Input.mousePosition;
        screenPoint = mainCam.WorldToScreenPoint(transform.position);
        Vector3 direction = (mousePos - transform.position).normalized;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot * 180);
        Destroy(gameObject, lifeTime);
    }


}