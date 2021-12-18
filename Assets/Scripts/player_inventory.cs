using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This implementation of the players inventory was implemented by way of the following tutorial:
// https://www.youtube.com/watch?v=_IqTeruf3-s&ab_channel=CodingWithUnity
public class player_inventory : MonoBehaviour
{
    public InventoryObject inventory;


    public void PurchaseItem(ItemSO item){
        Debug.Log("Purchased: " + item.title);
        // ItemObject item = transform.parent.gameObject;
        // int amount;

        inventory.AddItemToInventory(item, 1);
    }


    // Removes all the inventory items once the applcation is exited 
    private void OnApplicationQuit() {
        inventory.Container.Clear();
    }
}
