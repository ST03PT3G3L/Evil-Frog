using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool beingHovered;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        beingHovered = true;
    }

    private void OnMouseExit()
    {
        beingHovered = false;
    }
}
