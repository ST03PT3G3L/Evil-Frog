using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] MouseHover hover;
    [SerializeField] Transform origin;

    public bool isDragging;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (isDragging)
        {
            origin.position = hover.currentlyHovering.position;
        }
    }

    private void OnMouseDown()
    {


        if (isDragging)
        {
            if ()
            {

            }
            isDragging = false;
            renderer.color = Color.green;
        }
        else
        {
            isDragging = true;
            renderer.color = Color.red;
        }
    }

}
