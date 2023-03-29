using System;
using UnityEngine;

public class CryingPO : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] cryingSounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
