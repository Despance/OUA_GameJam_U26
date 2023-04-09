using UnityEngine;

public class PlayerPowerGiver : MonoBehaviour
{
    public void GiveJump()
    {
        PlayerData.canJump = true;
    }

    public void GiveRun()
    {
        PlayerData.canRun = true;
    }

    public void GiveExtraJump()
    {
        PlayerData.canExtraJump = true;
    }

    public void GiveReverseGravity()
    {
        PlayerData.canReverseGravity = true;
    }

    public void GiveShrink()
    {
        PlayerData.canShrink = true;
    }

    public void GiveMovePlatforms()
    {
        PlayerData.canMovePlatforms = true;
    }
}
