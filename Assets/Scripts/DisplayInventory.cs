using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This implementation of Inventory display was implemented by way of the following tutorial:
// https://www.youtube.com/watch?v=_IqTeruf3-s&ab_channel=CodingWithUnity
public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


    // The slot spacings
    public int x_spacing, y_spacing;
    public int x_start, y_start;
    public int n_columns;
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }


    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPos(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
        }
    }

    public Vector3 getPos(int i)
    {
        return new Vector3(x_start + x_spacing * (i % n_columns), y_start+(-y_spacing * (i/n_columns)), 0f);
    }

    public void UpdateDisplay() 
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPos(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();   
                itemsDisplayed.Add(inventory.Container[i], obj);             
            }

        }
    }

}
