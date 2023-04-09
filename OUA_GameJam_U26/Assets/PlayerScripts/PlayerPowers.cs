using DG.Tweening;
using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private Transform feet;

    [Header("MovingPlatform")] 
    public Rigidbody2D selectedPlatform;

    private RaycastHit2D movingGroundCheck;
    private Rigidbody2D rb;
    private Transform tf;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }
    
    void Update()
    {
        //reverse gravity
        if (Input.GetKeyDown(KeyCode.C) && PlayerData.canReverseGravity)
        {
            rb.gravityScale = -1 * rb.gravityScale;
            PlayerData.isFacedUp = !PlayerData.isFacedUp;
        }
        //reverse gravity

        //shrink
        if (Input.GetKeyDown(KeyCode.R) && PlayerData.isShrinked && PlayerData.canShrink)
        {
            tf.DOScale(new Vector3(1, 1, 1), 1f);
            PlayerData.isShrinked = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && !PlayerData.isShrinked && PlayerData.canShrink)
        {
            tf.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1f);
            PlayerData.isShrinked = true;
        }
        //shrink
        
        //move platform
        if (IsMovingGrounded() && PlayerData.canMovePlatforms)
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
        if (PlayerData.isFacedUp)
        {
            movingGroundCheck = Physics2D.Raycast(feet.position, Vector2.up, 0.1f);
        }
        
        else
        {
            movingGroundCheck = Physics2D.Raycast(feet.position, Vector2.down, 0.1f);
        }
        
        if (movingGroundCheck.collider != null)
        {
            PlayerData.isMovingGrounded = movingGroundCheck.collider.CompareTag("MovingGround");
        }
        
        else
        {
            PlayerData.isMovingGrounded = false;
        }

        return PlayerData.isMovingGrounded;
    }
}
