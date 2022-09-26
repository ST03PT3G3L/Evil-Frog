using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] MouseHover hover;
    [SerializeField] Transform origin;

    public bool placeable = true;
    public bool isDragging;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (isDragging && hover.currentlyHovering != null)
        {
            origin.position = hover.currentlyHovering.position;
        }
    }

    private void OnMouseDown()
    {
        if (isDragging && placeable)
        {

            isDragging = false;
            renderer.color = Color.blue;
        }
        else if(!isDragging)
        {
            isDragging = true;
            renderer.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trig");
        if (isDragging)
        {
            if (collision.gameObject.layer == 7)
            {
                placeable = false;
                renderer.color = Color.red;
            }
            else
            {
                placeable = true;
                renderer.color = Color.green;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        placeable = true;
        renderer.color = Color.green;
    }

}
