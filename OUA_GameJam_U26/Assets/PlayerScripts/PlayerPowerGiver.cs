using UnityEngine;

public class PlayerPowerGiver : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private PlayerData playerData;

    public void GiveJump()
    {
        playerData.canJump = true;
    }

    public void GiveRun()
    {
        playerData.canRun = true;
    }

    public void GiveExtraJump()
    {
        playerData.canExtraJump = true;
    }

    public void GiveReverseGravity()
    {
        playerData.canReverseGravity = true;
    }

    public void GiveShrink()
    {
        playerData.canShrink = true;
    }

    public void GiveMovePlatforms()
    {
        playerData.canMovePlatforms = true;
    }
}
