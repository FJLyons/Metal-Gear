using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private List<BaseItem> m_inventory = new List<BaseItem>();
	
    public void AddItemToInventory(BaseItem item)
    {
        m_inventory.Add(item);

        Debug.Log(
            item.ItemName + ": '" +
            item.ItemDescription + "' - [" +
            item.ItemIndex + "] [" +
            item.ItemType + "]");
    }

    public List<BaseItem> GetInventory()
    {
        return m_inventory;
    }
}
