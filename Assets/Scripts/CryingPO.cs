using UnityEngine;

public class CryingPO : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] cryingSounds;
    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private GameObject tearParticle;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayRandomCry", 4.0f, 4f);
        InvokeRepeating("SmolJump", 0.0f, 0.5f);
        rigidbody = GetComponent<Rigidbody>();
    }

    private void PlayRandomCry()
    {
        int random = Random.Range(0, cryingSounds.Length);
        audioSource.clip = cryingSounds[random];
        audioSource.Play();
    }

    private void SmolJump()
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
        rigidbody.AddForce(transform.up * 1, ForceMode.Impulse);
    }
}
