using UnityEngine;

public class FootStepHandler : MonoBehaviour
{

    private AudioSource footstepSound;
    private PlayerMovement playerMovement;

    public float normalSpeed;
    
    void Start()
    {
        footstepSound = GetComponent<AudioSource>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    
    void Update()
    {
        float speed = playerMovement.GetVelocityMagnitude();
        bool isGrounded = playerMovement.Grounded;
        if (speed > 0 && isGrounded)
        {
            footstepSound.mute = false;
            footstepSound.pitch = speed / normalSpeed;
        }
        else
        {
            footstepSound.mute = true;
        }
    }
}
