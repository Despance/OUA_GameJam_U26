using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource extraJumpSource;

    void LateUpdate()
    {
        if (PlayerData.jumpSound)
        {
            jumpSource.Play();
            PlayerData.jumpSound = false;
        }

        if (PlayerData.extraJumpSound)
        {
            extraJumpSource.Play();
            PlayerData.extraJumpSound = false;
        }
    }
}
