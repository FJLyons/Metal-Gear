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

	// Use this for initialization
	void Start () {
        CreateInventorySlots();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateInventorySlots()
    {
        xPos = startingPositionX;
        yPos = startingPositionY;

        for(int i = 0; i < slotCountMax; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Item Slot " + i;

            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(this.gameObject.transform, false);
            itemSlot.GetComponent<RectTransform>().localPosition =
                new Vector3(xPos, yPos, 0);

            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height + 4;

            itemSlotCount++;
            if(itemSlotCount % slotCountLength == 0) // remainder 0
            {
                xPos += (int)itemSlot.GetComponent<RectTransform>().rect.width * 5;
                yPos = startingPositionY;
                itemSlotCount = 0;
            }
        }
    }
}
