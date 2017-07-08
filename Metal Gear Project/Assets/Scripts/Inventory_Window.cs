using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Window : MonoBehaviour {

    public int startingPositionX;
    public int startingPositionY;

    public int slotCountMax;
    public int slotCountLength;

    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    private int xPos;
    private int yPos;
    private GameObject itemSlot;
    private int itemSlotCount;

    private List<GameObject> inventorySlots;
    private List<BaseItem> playerInventory;

    // Use this for initialization
    void Start() {
        CreateInventorySlots();
        AddItemsFromInventory();
    }

    // Update is called once per frame
    void Update() {

    }

    private void CreateInventorySlots()
    {
        inventorySlots = new List<GameObject>();

        xPos = startingPositionX;
        yPos = startingPositionY;

        for (int i = 0; i < slotCountMax; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(this.gameObject.transform, false);
            itemSlot.GetComponent<RectTransform>().localPosition =
                new Vector3(xPos, yPos, 0);

            inventorySlots.Add(itemSlot);

            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height + 4;

            itemSlotCount++;
            if (itemSlotCount % slotCountLength == 0) // remainder 0
            {
                xPos += ((int)itemSlot.GetComponent<RectTransform>().rect.width) + (72 * 4);
                yPos = startingPositionY;
                itemSlotCount = 0;
            }
        }
    }

    private void AddItemsFromInventory()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Snake").GetComponent<Inventory>();
        playerInventory = inventory.GetInventory();

        for (int i = 0; i < playerInventory.Count; i++)
        {
            if (inventorySlots[i].name == "Empty")
            {
                Debug.Log(i);
                inventorySlots[i].name = i.ToString();
                inventorySlots[i].transform.GetChild(0).gameObject.SetActive(true);
                inventorySlots[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ReturnItemIcon(playerInventory[i]);

            }
        }
    }

    private Sprite ReturnItemIcon(BaseItem item)
    {
        Sprite icon = new Sprite();

        Sprite[] sprites = Resources.LoadAll<Sprite>("UI/Items");

        if (item.ItemType == BaseItem.ItemTypes.CARD)
        {
            icon = sprites[11];
        }

        return icon;
    }

}
