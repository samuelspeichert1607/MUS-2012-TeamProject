using UnityEngine;

public class NonDiegeticalMusicManager : MonoBehaviour
{
    private const string BassName = "Bass";
    private const string ChordsName = "Chords";
    private const string DrumsName = "Drums";
    private const string MelodyName = "Melody";
    private const string PercName = "Perc";
    private const string GlobalObjectName = "GlobalObject";
    private int partitionCount;

    private void Start()
    {
        partitionCount = GetPartitionCount();
        SetLevelOfMusic();
    }

    private void SetLevelOfMusic()
    {
        PlayNewInstrument(BassName, 1);
        PlayNewInstrument(ChordsName, 2);
        PlayNewInstrument(DrumsName, 3);
        PlayNewInstrument(MelodyName, 4);
        PlayNewInstrument(PercName, 5);
    }

    private void PlayNewInstrument(string instrument, int minimalNumberOfPartitions)
    {
        if (partitionCount >= minimalNumberOfPartitions)
        {
            GameObject.Find(instrument).GetComponent<AudioSource>().volume = 1;
        }
    }

    private int GetPartitionCount()
    {
        GameObject globalObject = GameObject.Find(GlobalObjectName);
        return globalObject.GetComponent<Inventory>().Items.Count;
    }

    public void AddNewNumberOfPartitions(int newNumberOfPartitions)
    {
        partitionCount += newNumberOfPartitions;
        SetLevelOfMusic();
    }
}
