using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Weapon,
    Armor,
    Misc
}


// [CreateAssetMenu(fileName = "ItemObject", menuName = "Mead_and_Mjolnir/ItemObject", order = 0)]
public abstract class ItemObject : ScriptableObject {
    public GameObject prefab;
    public ItemType item;

    [TextArea(15, 20)] // This links to the description for the unity UI textbox size
    public string description; 

}
