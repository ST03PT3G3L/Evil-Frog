using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    [SerializeField] MouseHover hover;
    [SerializeField] Transform origin;
    [SerializeField] SpriteRenderer outline;
    private PathInventory pathInventory;

    public bool placeable = true;
    public bool isDragging;

    [SerializeField] AudioSource dropSound;
    [SerializeField] AudioClip[] pathPlaceSounds;

    private Color defaultColor;
    void Start()
    {
        GetNeededScripts();
        outline.enabled = false;
        defaultColor = outline.color;
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
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
                if(gameObject.tag != "Turret"){
                    PickUp();
                } 
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
                //outline.color = Color.red;
            }
            else
            {
                placeable = true;
               // outline.color = defaultColor;
            }
        }
    }

    public void PickUp()
    {
        if (gameObject.tag == "Path")
        {
            if (pathInventory == null || hover == null)
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
                PlayPathSound();
            }
            if (gameObject.tag == "Turret")
            {
                TowerUI myUI = GetComponent<TowerUI>();
                if (myUI != null) {
                    myUI.ResetUI();
                    myUI.clickable = true;
                }
            }
        }
    }

    private void PlayPathSound()
    {
        int n = Random.Range(1, pathPlaceSounds.Length);
        dropSound.clip = pathPlaceSounds[n];

        dropSound.PlayOneShot(dropSound.clip);

        pathPlaceSounds[n] = pathPlaceSounds[0];
        pathPlaceSounds[0] = dropSound.clip;
    }

    public void EnableMovement()
    {
        PickUp();
    }

}