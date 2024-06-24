using UnityEngine;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine.InputSystem;
public class ShotController : MonoBehaviour{

    public static SoundManager Instance;
    private Camera mainCam;
    private Vector3 screenPoint;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Start(){
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update(){

        mousePos = Input.mousePosition;
        screenPoint = mainCam.WorldToScreenPoint(transform.position); 

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Keyboard.current.eKey.wasPressedThisFrame && canFire)
        {   
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

}
