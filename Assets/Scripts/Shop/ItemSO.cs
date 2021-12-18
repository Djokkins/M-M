using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Menu", menuName = "Scriptable Objects/New Item", order = 1)]
public class ItemSO : ScriptableObject 
{
    // public ItemObject object_ref;
    public GameObject prefab;
    public string id;

    public string title;
    public string description;
    public int baseCost; 

    public Sprite itemImg;   

    
}

