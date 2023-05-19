using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulForge : MonoBehaviour
{
    [SerializeField] private List<GameObject> towersTheForgeSells;

    [SerializeField] ManageSoulForgeUI uiManager;
    [SerializeField] Currency curreny;
    [SerializeField] Transform pos;
    [SerializeField] Canvas canvas;
    private GameObject[] currentlySelling = new GameObject[2];

    private bool placing = false;
    private GameObject towerBuying;
    private Camera cam;
    public Sprite normalCursorSprite;

    private void Start()
    {
        cam = GameObject.Find("Main_Camera").GetComponent<Camera>();

        foreach (GameObject tower in towersTheForgeSells)
        {
            tower.GetComponent<Tower>().UpdateData();
        }

        setupShop(true);
    }

    public void BuyItem(int i)
    {
        Tower tower = currentlySelling[i].GetComponent<Tower>();
        tower.UpdateData();

        if (curreny.souls >= tower.price)
        {
            curreny.loseSouls((int)tower.price);
            towerBuying = currentlySelling[i];
            uiManager.disableButton(i);
            placing = true;
        }
    }

    private void InstantiateTower(GameObject tower)
    {
        GameObject newTower = Instantiate(tower.gameObject, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        newTower.transform.Translate(0, 0, 10);
    }

    private void Update()
    {
        if (placing)
        {
            canvas.enabled = false;
            if (!MouseHover.cursorSprite.enabled)
            {
                MouseHover.cursorSprite.enabled = true;
                MouseHover.cursorSprite.sprite = towerBuying.GetComponentInChildren<SpriteRenderer>().sprite;
                WhatToDoTextChanger.text.text = "Place " + towerBuying.GetComponent<Tower>().towerName + " somewhere...";
            }

            if(Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                placing = false;
                WhatToDoTextChanger.text.text = "";
                MouseHover.cursorSprite.sprite = normalCursorSprite;
                MouseHover.cursorSprite.enabled = false;

                InstantiateTower(towerBuying);
            }
        }
    }

    public void setupShop(bool start)
    {
        uiManager.enableButtons();

        int rndm1;
        if (start)
        {
            rndm1 = 0;
        }
        else
        {
            rndm1 = Random.Range(0, towersTheForgeSells.Count);
        }
        int rndm2 = Random.Range(0, towersTheForgeSells.Count);

        towersTheForgeSells[rndm1].GetComponent<Tower>().UpdateData();
        towersTheForgeSells[rndm2].GetComponent<Tower>().UpdateData();

        currentlySelling[0] = towersTheForgeSells[rndm1];
        currentlySelling[1] = towersTheForgeSells[rndm2];
        uiManager.updateUI(currentlySelling);
    }
}
