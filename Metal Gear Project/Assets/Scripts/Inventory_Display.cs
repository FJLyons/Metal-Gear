using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Display : MonoBehaviour {

    public GameObject itemMenu; // Assign in inspector
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            isShowing = !isShowing;
            itemMenu.SetActive(isShowing);
        }
    }
}
