using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Assign")]
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //animations
        if (PlayerData.isJumping && rb.velocity.y > 0)
        {
            animator.Play("PlayerJumping"); //name problem
        }
        else if (PlayerData.isJumping && rb.velocity.y < 0)
        {
            animator.Play("PlayerJumpingDown");
                
        }
        else if (PlayerData.isIdle)
        {
            animator.Play("PlayerIdle");
        }

        else if (PlayerData.isWalking)
        {
            animator.Play("PlayerWalking");
        }
        
        else if (PlayerData.isRunning)
        {
            animator.Play("PlayerRunning");   
        }
        //animations
        
        //looking directions
        spriteRenderer.flipX = !PlayerData.isFacedRight;
        spriteRenderer.flipY = PlayerData.isFacedUp;
        //looking directions
    }
}
