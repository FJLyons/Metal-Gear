using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private List<BaseItem> m_inventory = new List<BaseItem>();

    private BaseItem m_selectedItem;

    private bool m_itemIsSelected;

    void Start()
    {
        m_itemIsSelected = false;

        Sprite[] sprites = Resources.LoadAll<Sprite>("UI/Items");

        BaseItem cigs = new BaseItem(
                "Cig's", 
                "A pack of Lucky Strike cigarettes.", 
                0, 
                BaseItem.ItemTypes.CONSUMABLE,
                sprites[8]
            );

        AddItemToInventory(cigs);
    }
	
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

    public void SetSelectedItem(int id)
    {
        m_selectedItem = m_inventory[id];
    }

    public BaseItem GetSelectedItem()
    {
        return m_selectedItem;
    }

    public bool IsSelected
    {
        get { return m_itemIsSelected; }
        set { m_itemIsSelected = value; }
    }
}
