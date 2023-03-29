using UnityEngine;
using UnityEngine.SceneManagement;

public class FootStepHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footstepSoundHenriGagnon;

    [SerializeField]
    private AudioClip[] footstepSoundDesert;

    private AudioClip[] currentFootstepSounds;

    private AudioSource audioSource;

    private PlayerMovement playerMovement;

    public float normalSpeed;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponentInParent<PlayerMovement>();

        string currentSceneName = SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "lvl_henri_gagnon":
                currentFootstepSounds = footstepSoundHenriGagnon;
                break;
            case "Desert_Level":
                currentFootstepSounds = footstepSoundDesert;
                break;
            default:
                currentFootstepSounds = footstepSoundHenriGagnon;
                break;
        }
    }

    private void Update()
    {
        float speed = playerMovement.GetVelocityMagnitude();
        bool isGrounded = playerMovement.Grounded;

        int randomSoundIndex = Random.Range(0, currentFootstepSounds.Length - 1);

        audioSource.clip = currentFootstepSounds[randomSoundIndex];

        if (speed > 0 && isGrounded)
        {
            audioSource.mute = false;
            audioSource.pitch = speed / normalSpeed;
            //audioSource.Play();
            Invoke("PlaySound", randomSoundIndex);
        }
        else
        {
            audioSource.mute = true;
        }
    }


    void PlaySound()
    {
        Debug.Log("Hello!");
        //audioSource.Play();
    }
}
