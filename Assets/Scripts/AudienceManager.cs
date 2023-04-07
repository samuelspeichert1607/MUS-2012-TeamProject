using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudienceManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip crowdCheer;

    private GameObject[] spectators;
    private AudioSource bruitFoule;
    private int partitionCount;
    private void Start()
    {
        partitionCount = GetPartitionCount();
        bruitFoule = GameObject.Find("bruit_foule").GetComponent<AudioSource>();
        spectators = GameObject.FindGameObjectsWithTag("Spectator");
        SetLevelOfCrowdReaction();
    }

    private void SetLevelOfCrowdReaction()
    {
        switch (partitionCount)
        {
            case 0:
                IncitateSpectatorsToYellInsults(5, 13);
                LowerVolumeCrowdTo(0.5f);
                break;
            case 1:
                IncitateSpectatorsToYellInsults(10, 15);
                LowerVolumeCrowdTo(0.45f);
                break;
            case 2:
                IncitateSpectatorsToYellInsults(13, 26);
                LowerVolumeCrowdTo(0.3f);
                break;
            case 3:
                IncitateSpectatorsToYellInsults(30, 45);
                LowerVolumeCrowdTo(0.2f);
                break;
            case 4:
                IncitateSpectatorsToYellInsults(40, 60);
                LowerVolumeCrowdTo(0.1f);
                break;
            case 5:
                LowerVolumeCrowdTo(1f);
                ChangeAnimationOfAudienceToApplause();
                bruitFoule.GetComponent<AudioSource>().clip = crowdCheer;
                bruitFoule.GetComponent<AudioSource>().Play();
                break;
            default:
                break;
        }
    }

    private void ChangeAnimationOfAudienceToApplause()
    {
        for (int i = 0; i < spectators.Length; i++)
        {
            Animation animation = spectators[i].GetComponent<Animation>();
            string animationClipName = ChooseRandomAnimationClip();
            animation.clip = animation.GetClip(animationClipName);
            animation.Play();
        }
    }

    private string ChooseRandomAnimationClip()
    {
        int clipIndex = Random.Range(0,5);
        switch (clipIndex)
        {
            case 0:
                return "celebration";
            case 1:
                return "celebration2";
            case 2:
                return "celebration3";
            case 3:
                return "applause";
            case 4:
                return "applause2";
            default:
                return "applause";
        }
    }

    private void LowerVolumeCrowdTo(float volume)
    {
        bruitFoule.volume = volume;
    }

    private void IncitateSpectatorsToYellInsults(int minValueOfInsults, int maxValueOfInsults)
    {

        float randomDelay1 = Random.Range(minValueOfInsults, maxValueOfInsults);
        float randomDelay2 = 0;

        do
        {
            randomDelay2 = Random.Range(minValueOfInsults, maxValueOfInsults);
        }
        while (randomDelay2 == randomDelay1);
        
        StartCoroutine(ChooseASpectatorToShoutInsult(partitionCount, randomDelay1));
        StartCoroutine(ChooseASpectatorToShoutInsult(partitionCount, randomDelay2));
    }

    private int GetPartitionCount()
    {
        GameObject globalObject = GameObject.Find("GlobalObject");
        return globalObject.GetComponent<Inventory>().Items.Count;
    }

    private IEnumerator ChooseASpectatorToShoutInsult(int partitions, float delay)
    {
        int partitionCountAtThatTime = partitions;

        while (partitionCountAtThatTime == partitionCount)
        {
            yield return new WaitForSeconds(delay);

            if (partitionCountAtThatTime != partitionCount)
            {
                break;
            }

            int random = Random.Range(0, spectators.Length);
            GameObject chosenSpectator = spectators[random];
            chosenSpectator.GetComponent<PlayVoices>().ShoutInsult();
        }
    }
    
    public void AddNewNumberOfPartitions(int newNumberOfPartitions)
    {
        partitionCount += newNumberOfPartitions;
        SetLevelOfCrowdReaction();
    }
}
