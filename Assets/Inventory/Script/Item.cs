using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Equipment,
    Consumables,
    ETC
}

[System.Serializable]
public class Item 
{
    public ItemType ItemType;
    public string itemName;
    public Sprite itemImage;

    public bool Use(){
        return false;
    }
}
