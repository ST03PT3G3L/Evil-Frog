using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public Transform currentlyHovering;
    public bool isDraggingSomething;

    private void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform != null)
        {
            currentlyHovering = collision.transform;
        }
    }

    private void OnMouseDown()
    {
        if(currentlyHovering.tag == "Dragable")
        {
            DragDrop dragginObject = currentlyHovering.GetComponent<DragDrop>();
            dragginObject.isDragging = !dragginObject.isDragging;
        }
    }
}
