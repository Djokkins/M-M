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
    public ItemSO[] shopItemSO;     // List of all the items in the shop
    public GameObject[] shopPanelsGO;   // The shop panels themselves
    public ShopTemplate[] shopPanels;   // Shop template script
    public Button[] myPurchaseBtns;

    public InventoryObject userInventory;
    public player_inventory PlayerInventory;
    public GameObject InventoryPopUp;

    private static string COIN_SPRITE_ID = "<sprite=0>"; // The coin sprite for the text

    // public StaticData staticData;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        LoadPanels();
        UpdateCoinUI();
        

        // Getting a reference to the inventory scriptable object
        PlayerInventory = GameObject.Find("/PlayerInventory").GetComponent<player_inventory>();

        // Getting a reference to the Inventory UI
        InventoryPopUp = GameObject.Find("/Inventory_Canvas/InventoryPopUp");
        InventoryPopUp.SetActive(!InventoryPopUp.activeInHierarchy); // It has to be active in order to get a ref, so we set it to false on starts

        CheckPurchaseable();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryPopUp.SetActive(!InventoryPopUp.activeInHierarchy);
            Debug.Log("InventoryPopUp is set to: " + InventoryPopUp.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LogItAll();
        }
    }

    public void AddCoins()
    {
        coins += 500;
        UpdateCoinUI();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        // We check if we have enough gold
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if(coins >= shopItemSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }


        // We check if it is a stackable item, and if we have it to display that we already own it
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            for (int j = 0; j < PlayerInventory.inventory.Container.Count; j++)
            {
                if(PlayerInventory.inventory.Container[j].item == shopItemSO[i] && !shopItemSO[i].isStackable)
                {
                    shopPanels[i].btnTxt.text = "OWNED";
                    myPurchaseBtns[i].interactable = false;
                }    
            }
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemSO[btnNo].baseCost)
        {
            coins = coins - shopItemSO[btnNo].baseCost;     // Not messing with '-=' as that is some predefined subscriber pattern shit
            UpdateCoinUI();
            
            Debug.Log("Sprite of item: " + shopItemSO[btnNo].itemImg);
            PlayerInventory.PurchaseItem(shopItemSO[btnNo]);

            CheckPurchaseable();
        }
    }

    // Function to populate the show with the correct items
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanels[i].titleTxt.text         = shopItemSO[i].title;
            shopPanels[i].descriptionTxt.text   = shopItemSO[i].description;
            shopPanels[i].costTxt.text          = shopItemSO[i].baseCost.ToString() + COIN_SPRITE_ID;


            // NEVER GOT THIS TO WORK
            // Debug.Log("Item " + i + " has panel img: " + shopPanels[i].itemImg + " and itemSO sprite " + shopItemSO[i].itemImg);
            // shopPanels[i].itemImg.sprite        = shopItemSO[i].itemImg;
            //  shopPanels[i].spriteRenderer.sprite = shopItemSO[i].itemImg;
        }
    }

    private void UpdateCoinUI(){
        coinUI.text = "Coins: " + coins.ToString("n0") + COIN_SPRITE_ID;
    }



    public void BackToHub()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    private void LogItAll()
    {
         Debug.Log("Your inventory consists of: ");
        for (int i = 0; i < PlayerInventory.inventory.Container.Count; i++)
        {
            Debug.Log(PlayerInventory.inventory.Container[i].amount + " of " + PlayerInventory.inventory.Container[i].item.title);
        }
    }
}
