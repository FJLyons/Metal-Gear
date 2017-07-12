using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public int doorLevel;

    private Collider2D door;

    void Start()
    {
        door = this.transform.GetChild(0).gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D snake)
    {
        if (snake.gameObject.tag == "Snake")
        {
            if (doorLevel == 0)
            {
                door.isTrigger = true;
            }

            else if (snake.GetComponent<Inventory>().IsSelected)
            {
                if (snake.GetComponent<Inventory>().GetSelectedItem().ItemType == BaseItem.ItemTypes.CARD)
                {
                    if (snake.GetComponent<Inventory>().GetSelectedItem().CardLevel == doorLevel)
                    {
                        door.isTrigger = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D snake)
    {
        if (snake.gameObject.tag == "Snake")
        {
            if (door.isTrigger == true)
            {
                door.isTrigger = false;
            }
        }
    }
}
