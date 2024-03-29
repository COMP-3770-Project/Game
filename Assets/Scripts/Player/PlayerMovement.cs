using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 300;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private Rigidbody2D rb;
    
    private bool facingRight = true;
    private float moveDirection;
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
            Debug.Log(jumpCount);
            if(UpgradeManager.upgradesOwned.Contains(0)){
                if(jumpCount<2){
                    Jump();
                }
            }
            else{
                if(jumpCount<1){
                    Debug.Log("Jumped");
                    Jump();
                }
            }
            jumpCount++;
            
        }
        
        
    }
    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.layer==6){
            Debug.Log("Ground");
            jumpCount = 0;
        }
        if(c.gameObject.layer==10){
            player.TakeDamage(5);
        }
    }
}
