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
        if (isDragging)
        {
            origin.position = hover.currentlyHovering.position;
        }
    }

    private void OnMouseDown()
    {
        if (isDragging)
        {

            isDragging = false;
            renderer.color = Color.green;
        }
        else
        {
            isDragging = true;
            renderer.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");
        if (isDragging)
        {
            if (collision.gameObject.layer == 7)
            {
                placeable = false;
            }
            else
            {
                placeable = true;
            }
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
            }
            else
            {
                placeable = true;
            }
        }
    }

}
