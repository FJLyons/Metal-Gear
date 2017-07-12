using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Selected : MonoBehaviour {

    int ID;

    public GameObject snake; // Assign in inspector

    private BaseItem selectedItem; // Assign in inspector

    public GameObject itemWindow; // Assign in inspector

    void SetID(int id)
    {
        ID = id;
    }

    void SetItem()
    {
        Inventory inventory = snake.GetComponent<Inventory>();
        selectedItem = inventory.GetInventory()[ID];
    }

    void DisplayItem()
    {
        gameObject.GetComponent<Image>().sprite = selectedItem.icon;
    }

    public void OnToggle()
    {
        if (itemWindow.GetComponent<Inventory_Window>().inventorySlots[ID].gameObject.GetComponent<Toggle>().group.AnyTogglesOn() == true)
        {
            Debug.Log("Testing");
            gameObject.GetComponent<Item_Selected>().SetID(itemWindow.GetComponent<Inventory_Window>().GetSelectedItemID());

            if (ID >= 0)
            {
                gameObject.SetActive(true);
                gameObject.GetComponent<Item_Selected>().SetItem();
                gameObject.GetComponent<Item_Selected>().DisplayItem();
            }
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
