using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private List<BaseItem> m_inventory = new List<BaseItem>();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 3; i++)
        {
            BaseItem m_item = new BaseItem();
            m_inventory.Add(m_item);

            Debug.Log(
                m_inventory[i].ItemName + ": '" + 
                m_inventory[i].ItemDescription + "' - [" +
                m_inventory[i].ItemIndex + "] [" + 
                m_inventory[i].ItemType + "]");
        }

        Debug.Log(m_inventory.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
