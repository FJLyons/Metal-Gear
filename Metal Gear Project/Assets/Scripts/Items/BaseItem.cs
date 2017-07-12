using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem {

    private string m_name;
    private string m_description;
    private int m_index;

    private ItemTypes m_type;

    public Sprite icon;

    public BaseItem()
    {
        ItemName = "Empty";
        ItemDescription = "No item selected.";
        ItemIndex = -1;
        ItemType = ItemTypes.EMPTY;
        icon = Resources.Load<Sprite>("");
    }

    public BaseItem(string name, string desc, int i, ItemTypes type, Sprite spr)
    {
        ItemName = name;
        ItemDescription = desc;
        ItemIndex = i;
        ItemType = type;
        icon = spr;
    }


    public enum ItemTypes
    {
        EMPTY,
        CONSUMABLE, // Is consumed
        WEAPON,     // Is equipped and changes weapon 
        WEARABLE,   // Is equipeped and has effect
        CARD,       // Used for doors
        EXPLOSIVE   // Is equipped and planted
    }

    public string ItemName
    {
        get { return m_name; }
        set { m_name = value; }
    }

    public string ItemDescription
    {
        get { return m_description; }
        set { m_description = value; }
    }

    public int ItemIndex
    {
        get { return m_index; }
        set { m_index = value; }
    }

    public ItemTypes ItemType
    {
        get { return m_type; }
        set { m_type = value; }
    }
    
    //// CARD
    private int m_cardLevel;

    public BaseItem(string name, string desc, int i, ItemTypes type, Sprite spr, int cl)
    {
        ItemName = name;
        ItemDescription = desc;
        ItemIndex = i;
        ItemType = type;
        icon = spr;
        CardLevel = cl;
    }

    public int CardLevel
    {
        get { return m_cardLevel; }
        set { m_cardLevel = value; }
    }
}
