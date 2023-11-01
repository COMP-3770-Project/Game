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
    int jumpCount = 0;
    public GameObject isGround;
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
        Move();
    }
    private void Move(){
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }
    void Jump(){
            rb.AddForce(new Vector2(0f, jumpForce));
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
        
        if(Input.GetButtonDown("Jump")){
            
            if(UpgradeManager.upgradesOwned.Contains(0)){
                if(jumpCount<2){
                    Jump();
                }
            }
            else{
                if(jumpCount<1){
                    Jump();
                }
            }
            jumpCount++;
            
        }
        
        
    }
    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.layer==6){
            jumpCount = 0;
        }
    }
}
