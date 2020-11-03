using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] private int itemID;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;

    public Item(int id, string name, string desc)
    {
        this.itemID = id;
        this.itemName = name;
        this.itemDescription = desc;
    }

    public Item(int id, string name)
    {
        this.itemID = id;
        this.itemName = name;
    }
}

