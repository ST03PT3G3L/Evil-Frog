using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    [SerializeField] bool open = false;
    [SerializeField] Canvas canvas;
    
    public void OpenInventory()
    {
        if(open)
        {
            canvas.enabled = false;
            open = false;
        }
        else if(!open)
        {
            canvas.enabled = true;
            open = true;
        }
    }
}
