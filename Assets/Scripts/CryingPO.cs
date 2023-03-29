using UnityEngine;

public class CryingPO : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] cryingSounds;
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayRandomCry", 4.0f, 4f);
    }

    private void PlayRandomCry()
    {
        int random = Random.Range(0, cryingSounds.Length);
        audioSource.clip = cryingSounds[random];
        audioSource.Play();
    }
}
