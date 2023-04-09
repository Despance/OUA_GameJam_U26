using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private float speedDefault;
    [SerializeField] private float jumpSpeedDefault;
    [SerializeField] private float speedModifierDefault = 1f;
    [SerializeField] private float jumpSpeedModifierDefault = 1f;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float runningJumpSpeed;
    [SerializeField] private int extraJumpCountLimit;
    [SerializeField] private Transform feet;
    
    private float moveInput;
    private float speed;
    private float speedModifier;
    private float jumpSpeedModifier;
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
        rb.velocity = new Vector2(moveInput * speed * speedModifier, rb.velocity.y);
        //horizontal movement

        //state calculation
        if (moveInput != 0)
        {
            PlayerData.isIdle = false;
            PlayerData.isWalking = true;
            PlayerData.isRunning = false;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                PlayerData.isWalking = false;
                PlayerData.isRunning = true;
            }
            
            if (moveInput == 1f)
            {
                PlayerData.isFacedRight = true; 
            }

            else
            {
                PlayerData.isFacedRight = false;
            }
        }

        else if (!PlayerData.isJumping)
        {
            PlayerData.isIdle = true;
            PlayerData.isWalking = false;
            PlayerData.isRunning = false;
        }
        //state calculation
        
        //jump speed modifier
        if (PlayerData.isShrinked)
        {
            speedModifier = speedModifierDefault * 0.5f;
            jumpSpeedModifier = jumpSpeedModifierDefault * 0.25f;
        }
        
        else
        {
            speedModifier = speedModifierDefault;
            jumpSpeedModifier = jumpSpeedModifierDefault;
        }
        //jump speed modifier

        //ground check
        if (PlayerData.isFacedUp)
        {
            feet.localPosition = new Vector3(0, 0.8f, 0);
        }
        
        else
        {
            feet.localPosition = new Vector3(0, -0.8f, 0);
        }
        
        PlayerData.isGrounded = Physics2D.OverlapBox(feet.position, feet.localScale, 0);
        //ground check

        //jump buffer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferTimer = jumpBufferLimit;
            PlayerData.jumpSound = true; //sound state
        }

        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
        //jump buffer
        
        //coyote time
        if (PlayerData.isGrounded)
        {
            coyoteTimer = coyoteTimeLimit;
            extraJumpCounter = extraJumpCountLimit; //extra jump
            PlayerData.isJumping = false; //jump state
        }
        
        else
        {
            coyoteTimer -= Time.deltaTime;
        }
        //coyote time
        
        //jump
        if (coyoteTimer > 0f && jumpBufferTimer > 0f && PlayerData.canJump)
        {
            if (PlayerData.isFacedUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, -1 * jumpSpeed * jumpSpeedModifier);
            }
            
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * jumpSpeedModifier);
            }

            
             
            PlayerData.isJumping = true; //jump state
            PlayerData.isIdle = false;  //jump state
            
            
            
            
        }
        //jump
        
        //extra jump
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimer <= 0 && PlayerData.canExtraJump && extraJumpCounter > 0)
        {
            
            if (PlayerData.isFacedUp)
            {
                rb.velocity = new Vector2(rb.velocity.x, -1.25f * jumpSpeed * jumpSpeedModifier);
            }
            
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 1.25f * jumpSpeed * jumpSpeedModifier);
            }
            
            PlayerData.extraJumpSound = true; //sound state
            extraJumpCounter--;
            
        }
        //extra jump

        //running
        if (Input.GetKey(KeyCode.LeftShift) && PlayerData.canRun)
        {
            speed = runningSpeed;
            jumpSpeed = runningJumpSpeed;
        }
        
        else
        {
            speed = speedDefault;
            jumpSpeed = jumpSpeedDefault;
        }
        //running
    }
}
