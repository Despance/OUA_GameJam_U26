using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Abilities")]
    public bool canJump;
    public bool canRun;
    public bool canExtraJump;
    
    [Header("Animation States")]
    public bool isFacedRight;
    public bool isJumping;
    public bool isRunning;
    public bool isWalking;
    public bool isIdle;
    
    [Header("Non Animated States")]
    public bool isGrounded;
}
