using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Misc Object", menuName = "Invenory System/Items/Misc")]
public class MiscObject : ItemObject
{
    public float idk;
    public void Awake(){
        item = ItemType.Misc;
    }

}
