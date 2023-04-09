using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private PlayerPowers playerPowers;
    [SerializeField] private float platformSpeed = 10f;
    
    [Header("Status")]
    [SerializeField] private bool canMoveRight;
    [SerializeField] private bool canMoveLeft;
    [SerializeField] private int moveDirection;
    
    private Rigidbody2D rb;
    private Transform tf;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if (rb == playerPowers.selectedPlatform)
        {
            player.transform.SetParent(transform);
            
            if (Input.GetKeyDown(KeyCode.Q) && canMoveLeft)
            {
                moveDirection = -1;
            }
            
            else if (Input.GetKeyDown(KeyCode.E) && canMoveRight)
            {
                moveDirection = 1;
            }
        }

        else
        {
            player.transform.SetParent(null);
            moveDirection = 0;
        }

        if ((!canMoveLeft && moveDirection == -1) || (!canMoveRight && moveDirection == 1))
        {
            moveDirection = 0;
        }

        tf.Translate(new Vector2(moveDirection, 0) * (platformSpeed * Time.deltaTime));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatformLeft"))
        {
            canMoveLeft = false;
        }

        else if (other.CompareTag("MovingPlatformRight"))
        {
            canMoveRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canMoveRight = true;
        canMoveLeft = true;
    }
}
