using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour {

    [SerializeField] private int speed = 5;  //speed of player
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;


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
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement); //position + direction x frame
    }

}