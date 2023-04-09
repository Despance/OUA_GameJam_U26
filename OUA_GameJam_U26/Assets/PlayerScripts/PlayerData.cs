using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Abilities")]
    public static bool canJump;
    public static bool canRun;
    public static bool canExtraJump;
    public static bool canReverseGravity;
    public static bool canShrink;
    public static bool canMovePlatforms;

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
