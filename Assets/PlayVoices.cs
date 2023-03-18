using UnityEngine;

public class PlayVoices : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] voiceClips;
    private AudioSource audioSource;

    private float timePassed;
    private Random random;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timePassed = 0f;
    }
    
    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 3f)
        {
            int randomRange = Random.Range(0, voiceClips.Length);
            audioSource.clip = voiceClips[randomRange];
            audioSource.Play();
            timePassed = 0f;
        }
    }
}
