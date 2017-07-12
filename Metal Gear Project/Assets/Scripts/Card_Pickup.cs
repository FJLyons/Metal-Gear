using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Pickup : MonoBehaviour {

    public string m_name;
    public string m_description;
    public int m_index;

    private BaseItem.ItemTypes m_type;

    private Sprite m_icon;

    public int cardLevel;


    void OnTriggerEnter2D(Collider2D snake)
    {
        if (snake.gameObject.tag == "Snake")
        {
            Inventory inventory = snake.gameObject.GetComponent<Inventory>();

            m_type = BaseItem.ItemTypes.CARD;
            m_icon = this.gameObject.GetComponent<SpriteRenderer>().sprite;

            inventory.AddItemToInventory(new BaseItem(m_name, m_description, m_index, m_type, m_icon, cardLevel));

            Destroy(gameObject);
        }
    }
}
