using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        ProcessInputs();
        Animate();
    }
<<<<<<< HEAD:Assets/Scripts/Player/PlayerMovement.cs
    public void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
=======
    private void FixedUpdate(){
>>>>>>> main:Assets/Scripts/PlayerMovement.cs
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
<<<<<<< HEAD:Assets/Scripts/Player/PlayerMovement.cs

        if (isJumping)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }

=======
    }
    void Jump(){
            rb.AddForce(new Vector2(0f, jumpForce));
>>>>>>> main:Assets/Scripts/PlayerMovement.cs
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
<<<<<<< HEAD:Assets/Scripts/Player/PlayerMovement.cs

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJumping = true;
        }

=======
        
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
>>>>>>> main:Assets/Scripts/PlayerMovement.cs
    }
}
