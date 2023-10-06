using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 500;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private Rigidbody2D rb;
    
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGround;
    public float checkRadius;
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }
    private void FixedUpdate(){
        isGround = Physics2D.OverlapCircle(groundCheck.position,checkRadius,groundObjects);
        Move();
    }
    private void Move(){
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }
    private void Animate(){
        if(moveDirection>0 && !facingRight){
            FlipCharacter();
        }
        else if (moveDirection<0 && facingRight){
            FlipCharacter();
        }
    }
    private void FlipCharacter(){
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
    private void ProcessInputs(){
        moveDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGround){
            isJumping = true;
        }
        
    }
}
