using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource extraJumpSource;
    public AudioSource audiSource;
    public AudioClip[] voices;

    private PlayerData playerData;
    
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        audiSource.PlayOneShot(voices[0]);

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
