using DG.Tweening;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private Transform feet;

    [Header("Status")]
    [SerializeField] private bool isReverse;
    [SerializeField] private bool isShrinked;

    [Header("MovingPlatform")] 
    public Rigidbody2D selectedPlatform;

    private RaycastHit2D movingGroundCheck;
    private PlayerData playerData;
    private Rigidbody2D rb;
    private Transform tf;
    
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }
    
    void Update()
    {
        //reverse gravity
        if (Input.GetKeyDown(KeyCode.R) && playerData.canReverseGravity)
        {
            rb.gravityScale = -1 * rb.gravityScale;
            isReverse = !isReverse;
            playerData.isFacedUp = !playerData.isFacedUp;
        }
        //reverse gravity

        //shrink
        if (Input.GetKeyDown(KeyCode.C) && isShrinked && playerData.canShrink)
        {
            tf.DOScale(new Vector3(1, 1, 1), 1f);
            isShrinked = false;
        }
        else if (Input.GetKeyDown(KeyCode.C) && !isShrinked && playerData.canShrink)
        {
            tf.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1f);
            isShrinked = true;
        }
        //shrink
        
        //move platform
        if (IsMovingGrounded() && playerData.canMovePlatforms)
        {
            selectedPlatform = movingGroundCheck.rigidbody;
        }

        else
        {
            selectedPlatform = null;
        }
        //move platform
    }

    private bool IsMovingGrounded()
    {
        if (playerData.isFacedUp)
        {
            movingGroundCheck = Physics2D.Raycast(feet.position, Vector2.up, 0.1f);
        }
        
        else
        {
            movingGroundCheck = Physics2D.Raycast(feet.position, Vector2.down, 0.1f);
        }
        
        if (movingGroundCheck.collider != null)
        {
            playerData.isMovingGrounded = movingGroundCheck.collider.CompareTag("MovingGround");
        }
        
        else
        {
            playerData.isMovingGrounded = false;
        }

        return playerData.isMovingGrounded;
    }
}
