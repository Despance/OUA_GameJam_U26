using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Abilities")]
    public bool canJump;
    public bool canRun;
    public bool canExtraJump;

    [Header("Animation States")]
    public bool isFacedRight; //player controller
    public bool isFacedUp;
    public bool isRunning; //player controller
    public bool isWalking; //player controller
    public bool isIdle;    //player controller
    
    [Header("Non Animated States")]
    public bool isGrounded; //player controller
    public bool isJumping; //player controller
}
