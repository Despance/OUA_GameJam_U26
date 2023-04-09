using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource extraJumpSource;

    private PlayerData playerData;
    
    void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

    void LateUpdate()
    {
        if (playerData.jumpSound)
        {
            jumpSource.Play();
            playerData.jumpSound = false;
        }

        if (playerData.extraJumpSound)
        {
            extraJumpSource.Play();
            playerData.extraJumpSound = false;
        }
    }
}
