using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Parameters
    private static readonly int JumpTrigger = Animator.StringToHash("JumpTrigger");
    private static readonly int Speed = Animator.StringToHash("Speed");

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator and SpriteRenderer components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input or any other conditions to trigger animations
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger the "Jump" animation
            animator.SetTrigger(JumpTrigger);
        }

        // Simulate movement and adjust animation based on speed
        float horizontalInput = Input.GetAxis("Horizontal");
        float movementSpeed = 5f;
        transform.Translate(Vector2.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Update the "Speed" parameter for movement animation
        animator.SetFloat(Speed, Mathf.Abs(horizontalInput));

        // Flip the sprite based on movement direction
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    // Called from animation events (e.g., footstep sounds)
    public void PlayFootstepSound()
    {
        // Implement your logic to play footstep sound here
        Debug.Log("Footstep sound played!");
    }
}
