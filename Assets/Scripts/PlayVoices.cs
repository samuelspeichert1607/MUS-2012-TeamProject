using System;
using UnityEngine;

public class PlayVoices : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] voiceClips;
    private AudioSource audioSource;

    private float timePassed;
    //private Random random;
    float randomTime;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timePassed = 0f;
        //randomTime = Random.Range(7, 12);
    }

    public void ShoutInsult()
    {
        int randomRange = UnityEngine.Random.Range(0, voiceClips.Length);
        audioSource.clip = voiceClips[randomRange];
        audioSource.Play();
    }

    /*private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > randomTime)
        {
            int randomRange = Random.Range(0, voiceClips.Length);
            audioSource.clip = voiceClips[randomRange];
            audioSource.Play();
            timePassed = 0f;
        }
    }*/
}
