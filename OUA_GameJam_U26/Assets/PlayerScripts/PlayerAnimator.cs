using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Assign")]
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerData playerData;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerData = GetComponent<PlayerData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //animations
        if (playerData.isJumping && rb.velocity.y > 0)
        {
            animator.Play("PlayerJumping"); //name problem
        }
        else if (playerData.isJumping && rb.velocity.y < 0)
        {
            animator.Play("PlayerJumpingDown");
                
        }
        else if (playerData.isIdle)
        {
            animator.Play("PlayerIdle");
        }

        else if (playerData.isWalking)
        {
            animator.Play("PlayerWalking");
        }
        
        else if (playerData.isRunning)
        {
            animator.Play("PlayerRunning");   
        }
        //animations
        
        //looking directions
        spriteRenderer.flipX = !playerData.isFacedRight;
        spriteRenderer.flipY = playerData.isFacedUp;
        //looking directions
    }
}
