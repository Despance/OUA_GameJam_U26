using UnityEngine;

public class PlayerData : MonoBehaviour
{
    
    [Header("Abilities")]
    public static bool canJump = true;
    public static bool canRun = false;
    public static bool canExtraJump = false;
    public static bool canReverseGravity = false;
    public static bool canShrink = false;
    public static bool canMovePlatforms = false;

    [Header("Animation States")]
    public static bool isFacedRight; //player controller
    public static bool isFacedUp; //player powers
    public static bool isRunning; //player controller
    public static bool isWalking; //player controller
    public static bool isIdle;    //player controller

    [Header("Sound States")]
    public static bool jumpSound;
    
    [Header("Non Animated States")]
    public static bool isMovingGrounded; //player powers
    public static bool isGrounded; //player controller
    public static bool isJumping; //player controller
    public static bool isShrinked; //player powers
}
