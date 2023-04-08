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
    private float coyoteTimeLimit = 0.2f;
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
        if (IsGrounded())
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
        if (Input.GetKeyDown(KeyCode.Space) && playerData.canExtraJump && !IsGrounded() && extraJumpCounter > 0)
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
    
    private bool IsGrounded()
    {
        RaycastHit2D groundCheck;
        
        if (playerData.isFacedUp)
        {
            feet.localPosition = new Vector3(0, 0.75f, 0);
            groundCheck = Physics2D.Raycast(feet.position, Vector2.up, 0.1f);
        }
        
        else
        {
            feet.localPosition = new Vector3(0, -0.75f, 0);
            groundCheck = Physics2D.Raycast(feet.position, Vector2.down, 0.1f);
        }
        
        if (groundCheck.collider != null)
        {
            playerData.isGrounded = groundCheck.collider.CompareTag("Ground") || groundCheck.collider.CompareTag("MovingGround");
        }
        
        else
        {
            playerData.isGrounded = false;
        }

        return playerData.isGrounded;
    }
}
