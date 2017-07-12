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

        snake.GetComponent<Inventory>().SetSelectedItem(ID);
    }

    void DisplayItem()
    {
        gameObject.GetComponent<Image>().sprite = selectedItem.icon;
    }

    public void OnToggle()
    {
        if (itemWindow.GetComponent<Inventory_Window>().inventorySlots[ID].gameObject.GetComponent<Toggle>().group.AnyTogglesOn() == true)
        {
            gameObject.GetComponent<Item_Selected>().SetID(itemWindow.GetComponent<Inventory_Window>().GetSelectedItemID());

            if (ID >= 0)
            {
                snake.GetComponent<Inventory>().IsSelected = true;
                gameObject.SetActive(true);
                gameObject.GetComponent<Item_Selected>().SetItem();
                gameObject.GetComponent<Item_Selected>().DisplayItem();
                DisplayQuantity();
            }
        }

        else
        {
            snake.GetComponent<Inventory>().IsSelected = false;
            gameObject.SetActive(false);
            StopDisplayQuantity();
        }
    }

    void DisplayQuantity()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        if (snake.GetComponent<Inventory>().GetSelectedItem().ItemType == BaseItem.ItemTypes.CARD)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = snake.GetComponent<Inventory>().GetSelectedItem().CardLevel.ToString();
        }

        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        }
    }

    void StopDisplayQuantity()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
    }
}
