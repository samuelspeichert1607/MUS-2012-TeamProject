using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> Items { get; set; }


    private void Start()
    {
        Items = new List<Item>();
        GameEvents.SaveInitiated();
    }

    [SerializeField]
    private ItemDatabase database;

    public void AddItem(string itemName)
    {
        Item itemToAdd = database.GetItem(itemName);
        Items.Add(itemToAdd);
        GameEvents.OnItemAddedToInventory(itemToAdd);
        Debug.Log("Item Added");
    }

    public void AddItems(List<Item> items)
    {
        foreach(Item item in items)
        {
            AddItem(item.itemName);
        }
    }

    public void Save()
    {
        SaveLoad.Save<List<Item>>(Items, "Inventory");
    }
     
     
}
