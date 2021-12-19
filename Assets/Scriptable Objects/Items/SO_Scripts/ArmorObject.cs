using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Invenory System/Items/Armor")]
public class ArmorObject : ItemObject
{
    public float Resistance;
    public void Awake(){
        item = OldType.Armor;
    }

}
