using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This implementation of inventory object was implemented by way of the following tutorial:
// https://www.youtube.com/watch?v=_IqTeruf3-s&ab_channel=CodingWithUnity
[CreateAssetMenu(fileName = "New Inventory", menuName = "Invenory System/Inventory")]
public class InventoryObject : ScriptableObject 
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItemToInventory(ItemSO _item, int _amount)
    {
        // We first check if the item is already in our inventory
        bool hasItem = false; //Assume it is false to begin with 
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                hasItem = true;
                Container[i].AddAmount(_amount);
                return;
            }
        }
        if(!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;

    // We have the amount of an item in every slot for stackables such as potions
    public int amount;

    // Inventory slot constructer
    public InventorySlot(ItemSO _item, int _amount)
    {
        item    = _item;
        amount  = _amount;
    }

    public void AddAmount(int _amount)
    {
        amount += _amount;
    }
}
