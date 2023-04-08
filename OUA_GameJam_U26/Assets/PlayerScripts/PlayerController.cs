using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private float speedDefault;
    [SerializeField] private float jumpSpeedDefault;
    [SerializeField] private float speedRunning;
    [SerializeField] private float jumpSpeedRunning;
    [SerializeField] private int extraJumpCountLimit;
    [SerializeField] private Transform feet;
    [SerializeField] private PlayerData playerData;

    private float moveInput;
    private float speed;
    private float jumpSpeed;
    private float jumpBufferLimit = 0.2f;
    private float jumpBufferTimer;
    private float coyoteTimeLimit = 0.3f;
    private float coyoteTimer;
    private int extraJumpCounter;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //horizontal movement

        //state calculation
        if (moveInput != 0)
        {
            playerData.isIdle = false;
            playerData.isWalking = true;
            playerData.isRunning = false;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerData.isWalking = false;
                playerData.isRunning = true;
            }
            
            if (moveInput == 1f)
            {
                playerData.isFacedRight = true; 
            }

            else
            {
                playerData.isFacedRight = false;
            }
        }

        else if (!playerData.isJumping)
        {
            playerData.isIdle = true;
            playerData.isWalking = false;
            playerData.isRunning = false;
        }
        //state calculation

        //ground check
        if (playerData.isFacedUp)
        {
            feet.localPosition = new Vector3(0, 0.8f, 0);
        }
        
        else
        {
            feet.localPosition = new Vector3(0, -0.8f, 0);
        }
        
        playerData.isGrounded = Physics2D.OverlapBox(feet.position, feet.localScale, 0);
        //ground check

        //jump buffer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferTimer = jumpBufferLimit;
        }

        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
        //jump buffer
        
        //coyote time
        if (playerData.isGrounded)
        {
            coyoteTimer = coyoteTimeLimit;
            extraJumpCounter = extraJumpCountLimit; //extra jump
            playerData.isJumping = false; //jump state
        }
        
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
        //coyote time
        
        //jump
        if (coyoteTimer > 0f && jumpBufferTimer > 0f && playerData.canJump)
        {
            if (playerData.isFacedUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, -1 * jumpSpeed);
            }
            
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            
            playerData.isJumping = true; //jump state
            playerData.isIdle = false;  //jump state
        }
        //jump
        
        //extra jump
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimer <= 0 && playerData.canExtraJump && extraJumpCounter > 0)
        {
            
            if (playerData.isFacedUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, -1.25f * jumpSpeed);
            }
            
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 1.25f * jumpSpeed);
            }
            extraJumpCounter--;
        }
        //extra jump

        //running
        if (Input.GetKey(KeyCode.LeftShift) && playerData.canRun)
        {
            speed = speedRunning;
            jumpSpeed = jumpSpeedRunning;
        }
        
        else
        {
            speed = speedDefault;
            jumpSpeed = jumpSpeedDefault;
        }
        //running
    }
}
