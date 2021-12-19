using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Invenory System/Items/Weapons")]
public class WeaponObject : ItemObject
{
    public float DmgAmp;
    public float AttackSpeed;
    // public float Range;
    public void Awake() {
        item = OldType.Weapon;
    }
}
