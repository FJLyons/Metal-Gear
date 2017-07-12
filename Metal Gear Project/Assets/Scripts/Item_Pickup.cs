using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public string m_name;
    public string m_description;
    public int m_index;

    public BaseItem.ItemTypes m_type;

    private Sprite m_icon;


    void OnTriggerEnter2D(Collider2D snake)
    {
        if (snake.gameObject.tag == "Snake")
        {
            Destroy(gameObject);

            Inventory inventory = snake.gameObject.GetComponent<Inventory>();

            m_icon = this.gameObject.GetComponent<SpriteRenderer>().sprite;

            inventory.AddItemToInventory(new BaseItem(m_name, m_description, m_index, m_type, m_icon));
        }
    }
}
