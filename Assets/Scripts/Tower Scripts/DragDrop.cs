using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] MouseHover hover;
    [SerializeField] Transform origin;
    [SerializeField] GameObject outline;

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

    private void OnMouseEnter()
    {
        if (outline != null)
        {
            outline.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (outline != null)
        {
            outline.SetActive(false);
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
                if(gameObject.tag == "Path")
                {
                    gameObject.GetComponent<PathCollision>().CheckCollisions();
                }

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
                outline.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                placeable = true;
                outline.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }



}
