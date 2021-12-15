using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Menu", menuName = "Scriptable Objects/New Item", order = 1)]
public class ItemSO : ScriptableObject 
{
    public string id;

    public string title;
    public string description;
    public int baseCost; 

    public Sprite itemImg;   

    public GameObject prefab;
}

