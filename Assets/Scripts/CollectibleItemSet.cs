using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemSet : MonoBehaviour
{
    private const string Key = "CollectedItems";

    public HashSet<string> CollectedItems { get; private set; } = new HashSet<string>();

    private void Awake()
    {
        GameEvents.SaveInitiated += Save;
        Load();
    }

    private void Save()
    {
        SaveLoad.Save(CollectedItems, Key);
    }

    private void Load()
    {
        if (SaveLoad.SaveExists(Key))
        {
            CollectedItems = SaveLoad.Load<HashSet<string>>(Key);
        }
    }
}
