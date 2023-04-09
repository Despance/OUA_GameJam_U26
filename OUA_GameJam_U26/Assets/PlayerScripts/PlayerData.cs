using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Abilities")]
    public static bool canJump = true;
    public static bool canRun = true;
    public static bool canExtraJump = true;
    public static bool canReverseGravity = true;
    public static bool canShrink = true;
    public static bool canMovePlatforms = true;

    [Header("Animation States")]
    public static bool isFacedRight; //player controller
    public static bool isFacedUp; //player powers
    public static bool isRunning; //player controller
    public static bool isWalking; //player controller
    public static bool isIdle;    //player controller

    [Header("Sound States")]
    public static bool jumpSound;
    public static bool extraJumpSound;
    
    [Header("Non Animated States")]
    public static bool isMovingGrounded; //player powers
    public static bool isGrounded; //player controller
    public static bool isJumping; //player controller
    public static bool isShrinked; //player powers
}
