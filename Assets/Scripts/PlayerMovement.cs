using UnityEngine;
using UnityEngine.InputSystem;


public class Player2Movement : MonoBehaviour {

    [SerializeField] private int speed = 5;  //speed of player
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    public int coins;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement (InputValue value){
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0){
            animator.SetFloat("X", movement.x); //horizontal movement
            animator.SetFloat("Y", movement.y); //vertical movement
        
            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }
    }    
    private void FixedUpdate() {
        //Varient 1
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //position + direction x frame

        //Varient 2
        //if(movement.x != 0 || movement.y != 0){
           //rb.velocity = movement * speed; //velocity = direction x speed and force to a rigidbody
        //}

       //Variant 3
       //rb.AddForce(movement * speed); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            coins++;
        }
    }
}