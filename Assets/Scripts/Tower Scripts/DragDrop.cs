using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] MouseHover hover;
    [SerializeField] Transform origin;

    public bool placeable = true;
    public bool isDragging;
    //private SpriteRenderer renderer;

    void Start()
    {
        //renderer = GetComponent<SpriteRenderer>();
        if(GameObject.Find("HoverCheck").GetComponent<MouseHover>() != null)
        {
            hover = GameObject.Find("HoverCheck").GetComponent<MouseHover>();
        }
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
        if (ModeManager.editMode)
        {
            if (isDragging && placeable)
            {
                isDragging = false;
                hover.isDraggingSomething = false;
                gameObject.GetComponent<PathCollision>().CheckCollisions();
                //renderer.color = Color.blue;
            }
            else if (!isDragging && !hover.isDraggingSomething)
            {
                hover.isDraggingSomething = true;
                isDragging = true;
                //renderer.color = Color.green;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDragging)
        {
            placeable = true;
            //renderer.color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDragging)
        {
            if (collision.gameObject.layer == 7)
            {
                placeable = false;
                //renderer.color = Color.red;
            }
            else
            {
                placeable = true;
                //renderer.color = Color.green;
            }
        }
    }



}
