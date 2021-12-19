using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    Weapon,
    Armor,
    Misc,
    Boots
}



[CreateAssetMenu(fileName = "Menu", menuName = "Scriptable Objects/New Item", order = 1)]
public class ItemSO : ScriptableObject 
{
    // public ItemObject object_ref;
    public GameObject prefab;
    // public string id;

    public string title;
    public string description;
    public int baseCost; 

    public bool isStackable;

    public Sprite itemImg;   

    public ItemType itemType;


    public ItemType getItemType()
    {
        return this.itemType;
    }

    
}

