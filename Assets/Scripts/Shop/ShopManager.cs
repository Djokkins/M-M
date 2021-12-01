using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO;     // List of all the items in the shop
    public GameObject[] shopPanelsGO;   // The shop panels themselves
    public ShopTemplate[] shopPanels;   // Shop template script
    public Button[] myPurchaseBtns;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        LoadPanels();
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins += 10;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if(coins >= shopItemSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemSO[btnNo].baseCost)
        {
            coins = coins - shopItemSO[btnNo].baseCost;     // Not messing with '-=' as that is some predefined subscriber pattern shit
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
            // TODO: Unlock item 
        }
    }

    // Function to populate the show with the correct items
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleTxt.text         = shopItemSO[i].title;
            shopPanels[i].descriptionTxt.text   = shopItemSO[i].description;
            shopPanels[i].costTxt.text          = shopItemSO[i].baseCost.ToString();
        }
    }


    public void BackToHub()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
