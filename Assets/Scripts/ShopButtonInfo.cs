using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    public Text ItemTxt;
    public Text PriceTxt;

    public GameObject ShopManager;
    


    void Start()
    {
        PriceTxt.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
    }
}
