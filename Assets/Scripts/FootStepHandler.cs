using System.Collections;
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

    private Animator animator;

    public float normalSpeed;

    private bool isWalking = false;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        animator = GameObject.Find("Mummy_Mon").GetComponent<Animator>();

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

        StartCoroutine(PlayStepsSounds());
    }

    private void Update()
    {
        float speed = playerMovement.GetVelocityMagnitude();
        bool isGrounded = playerMovement.Grounded;
        isWalking = (speed > 0 && isGrounded) ? true : false;
    }

    private IEnumerator PlayStepsSounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (isWalking)
            {
                int random = Random.Range(0, currentFootstepSounds.Length);
                audioSource.clip = currentFootstepSounds[random];
                audioSource.Play();
            }
        }
    }
    
}
