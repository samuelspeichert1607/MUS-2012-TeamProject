using System;
using UnityEngine;

public class PlayVoices : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] voiceClips;
    private AudioSource audioSource;
    private float timePassed;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timePassed = 0f;
    }

    public void ShoutInsult()
    {
        int randomRange = UnityEngine.Random.Range(0, voiceClips.Length);
        audioSource.clip = voiceClips[randomRange];
        audioSource.Play();
    }
}
