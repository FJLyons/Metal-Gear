using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Display : MonoBehaviour {

    public GameObject itemWindow; // Assign in inspector
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            isShowing = !isShowing;
            itemWindow.SetActive(isShowing);
            itemWindow.GetComponent<Inventory_Window>().RefreshWindow();
        }
    }
}
