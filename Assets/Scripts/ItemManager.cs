using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Item[] items;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Item aanmaken");
        items[0] = new Item(0, "Sword of Thousand Truths", "Depletes all mana on hit!");
        items[1] = new Item(1, "Excalibur");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
