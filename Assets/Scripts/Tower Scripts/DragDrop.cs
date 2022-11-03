using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    [SerializeField] MouseHover hover;
    [SerializeField] Transform origin;
    [SerializeField] GameObject outline;
    private PathInventory pathInventory;

    public bool placeable = true;
    public bool isDragging;

    void Start()
    {
        GetNeededScripts();
    }

    private void GetNeededScripts()
    {
        if (GameObject.Find("HoverCheck").GetComponent<MouseHover>() != null)
        {
            hover = GameObject.Find("HoverCheck").GetComponent<MouseHover>();
        }

        if (GameObject.Find("PathInventory").GetComponent<PathInventory>() != null)
        {
            pathInventory = GameObject.Find("PathInventory").GetComponent<PathInventory>();
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
            if (isDragging)
            {
                DropDown();
            }
            else if (!isDragging && !hover.isDraggingSomething && !EventSystem.current.IsPointerOverGameObject())
            {
                PickUp();
            }
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.5f);
        pathInventory.currentPath = null;
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

    public void PickUp()
    {
        if (gameObject.tag == "Path")
        {
            if(pathInventory == null || hover == null)
            {
                GetNeededScripts();
            }
            pathInventory.currentPath = gameObject;
        }
        hover.isDraggingSomething = true;
        isDragging = true;
    }

    public void DropDown()
    {
        if (placeable)
        {
            isDragging = false;
            hover.isDraggingSomething = false;
            if (gameObject.tag == "Path")
            {
                gameObject.GetComponent<PathCollision>().CheckCollisions();
                StartCoroutine(timer());
            }
        }
    }

}
