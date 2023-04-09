using UnityEngine;

public class PlayerPowerGiver : MonoBehaviour
{
    public static void GiveJump()
    {
        PlayerData.canJump = true;
    }

    public static void GiveRun()
    {
        PlayerData.canRun = true;
    }

    public static void GiveExtraJump()
    {
        PlayerData.canExtraJump = true;
    }

    public static void GiveReverseGravity()
    {
        PlayerData.canReverseGravity = true;
    }

    public static void GiveShrink()
    {
        PlayerData.canShrink = true;
    }

    public static void GiveMovePlatforms()
    {
        PlayerData.canMovePlatforms = true;
    }
}
