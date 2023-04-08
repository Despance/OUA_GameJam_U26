using UnityEngine;

public class PlayerPowers : MonoBehaviour
{
    [Header("Status")] 
    [SerializeField] private bool isReverse;
    [SerializeField] private bool isShrinked;

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
        if (Input.GetKeyDown(KeyCode.E) && playerData.canReverseGravity)
        {
            rb.gravityScale = -1 * rb.gravityScale;
            isReverse = !isReverse;
            playerData.isFacedUp = !playerData.isFacedUp;
        }
        //reverse gravity

        //shrink
        if (Input.GetKeyDown(KeyCode.C) && isShrinked && playerData.canShrink)
        {
            tf.localScale = new Vector3(1, 1, 1);
            isShrinked = false;
        }
        else if (Input.GetKeyDown(KeyCode.C) && !isShrinked && playerData.canShrink)
        {
            tf.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            isShrinked = true;
        }
        //shrink
    }
}
