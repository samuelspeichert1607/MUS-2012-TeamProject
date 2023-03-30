using UnityEngine;
using Random = UnityEngine.Random;

public class AudienceManager : MonoBehaviour
{
    private GameObject[] spectators;
    private AudioSource bruitFoule;
    private int partitionCount;

    private void Start()
    {
        partitionCount = GetPartitionCount();
        bruitFoule = GameObject.Find("bruit_foule").GetComponent<AudioSource>();
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
                //IncitateSpectatorsToYellInsults(15, 30);
                LowerVolumeCrowdTo(0);
                //Applause
                break;
            default:
                break;
        }
    }

    private void LowerVolumeCrowdTo(float volume)
    {
        bruitFoule.volume = volume;
    }

    private void IncitateSpectatorsToYellInsults(int minValueOfInsults, int maxValueOfInsults)
    {
        spectators = GameObject.FindGameObjectsWithTag("Spectator");

        float randomDelay1 = Random.Range(minValueOfInsults, maxValueOfInsults);
        float randomDelay2 = 0;

        do
        {
            randomDelay2 = Random.Range(minValueOfInsults, maxValueOfInsults);
        }
        while (randomDelay2 == randomDelay1);

        InvokeRepeating("ChooseASpectatorToShoutInsult", 0.0f, randomDelay1);
        InvokeRepeating("ChooseASpectatorToShoutInsult", 0.0f, randomDelay2);
    }

    private int GetPartitionCount()
    {
        GameObject globalObject = GameObject.Find("GlobalObject");
        return globalObject.GetComponent<Inventory>().Items.Count;
    }

    private void ChooseASpectatorToShoutInsult()
    {
        int random = Random.Range(0, spectators.Length);
        GameObject chosenSpectator  = spectators[random];
        chosenSpectator.GetComponent<PlayVoices>().ShoutInsult();
    }
    
    public void AddNewNumberOfPartitions(int newNumberOfPartitions)
    {
        partitionCount += newNumberOfPartitions;
        SetLevelOfCrowdReaction();
    }
}
