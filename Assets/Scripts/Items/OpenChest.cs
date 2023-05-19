using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenChest : MonoBehaviour
{
    GameObject itemInChest;
    private int rndm;
    private Canvas itemCanvas;
    private ManageUI uiManager;
    [SerializeField] GameObject outline;

    [SerializeField] private AudioSource itemGetSource;

    void Start()
    {
        itemCanvas = GameObject.Find("NewItemCanvas").GetComponent<Canvas>();
        uiManager = GameObject.Find("UI Manager").GetComponent<ManageUI>();

        if(ItemPool.itemPool[0] != null)
        {
            rndm = Random.Range(0, ItemPool.itemPool.Count);
            itemInChest = ItemPool.itemPool[rndm];
        }   
    }

    private void OnMouseDown()
    {
        itemGetSource.Play();
        Instantiate(itemInChest);
        itemInChest.GetComponent<Item>().UpdateData();
        updateUI();
        if(ItemPool.itemPool.Count == 1)
        {
            Debug.Log("Pool Empty!");
            ItemPool.itemPool[0] = null;
        }

        ItemPool.itemPool.RemoveAt(rndm);
        gameObject.GetComponent<Transform>().localPosition = new Vector2(-500, -500);
        Destroy(gameObject, 2.5f);
    }

    public void updateUI()
    {
        itemCanvas.GetComponentInChildren<TextMeshProUGUI>().text = itemInChest.GetComponent<Item>().description;
        itemCanvas.GetComponentInChildren<Image>().sprite = itemInChest.GetComponent<Item>().sprite;
        uiManager.ActivateUI(itemCanvas);
    }

    private void OnMouseEnter()
    {
        Debug.Log("MouseEnter");
        if (outline != null)
        {
            outline.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("MouseExit");
        if (outline != null)
        {
            outline.SetActive(false);
        }
    }
}
