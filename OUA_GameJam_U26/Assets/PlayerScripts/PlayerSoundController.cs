using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource extraJumpSource;
    [SerializeField] private AudioClip jumpSound;
    

    void LateUpdate()
    {
        if (PlayerData.jumpSound)
        {
            jumpSource.Play();
            PlayerData.jumpSound = false;
            
        }
    }
}
