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
        Instantiate(itemInChest);
        itemInChest.GetComponent<Item>().UpdateData();
        updateUI();

        if(ItemPool.itemPool.Count == 1)
        {
            Debug.Log("Pool Empty!");
            ItemPool.itemPool[0] = null;
            return;
        }

        ItemPool.itemPool.RemoveAt(rndm);
        Destroy(gameObject);
    }

    public void updateUI()
    {
        itemCanvas.GetComponentInChildren<TextMeshProUGUI>().text = itemInChest.GetComponent<Item>().description;
        itemCanvas.GetComponentInChildren<Image>().sprite = itemInChest.GetComponent<Item>().sprite;
        uiManager.ActivateUI(itemCanvas);
    }
}
