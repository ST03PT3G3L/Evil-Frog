using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerUI : MonoBehaviour
{
    public Sprite defaultCursorSprite;
    public GameObject canvas;
    public SpriteRenderer border;
    public bool disableOnMove = true;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI upgrade1BoughtText;
    public TextMeshProUGUI upgrade2BoughtText;

    [SerializeField] private GameObject rangeOutline;
    public float upgrade1Bought;
    public float upgrade2Bought;

    [HideInInspector] public bool clickable = true;
    private void Start()
    {
        border.enabled = false;
        canvas.SetActive(false);

        if(gameObject.tag == "Turret")
        {
            GetComponentInParent<Tower>().UpdateData();
            nameText.text = GetComponentInParent<Tower>().towerName;
        }
    }

    private void OnMouseEnter()
    {
        if(gameObject.tag == "Player")
        {
            border.enabled = true;
        }
        else
        {
            GetComponentInParent<Tower>().UpdateData();
        }
    }


    private void OnMouseExit()
    {
        if(gameObject.tag == "Player")
        {
            border.enabled = false;
        }
    }


    private void OnMouseDown()
    {
        if (clickable)
        {
            if (canvas.activeSelf == true)
            {
                canvas.SetActive(false);
                rangeOutline.SetActive(false);
            }

            if(canvas.activeSelf == false)
            {
                canvas.SetActive(true);
                rangeOutline.SetActive(true);
            }
        }
    }


    public void openPlayerUI(bool openOrNot)
    {
        canvas.SetActive(openOrNot);
        if(openOrNot == false)
        {
            rangeOutline.SetActive(false);
        }
    }

    public void enableMovementOnObject()
    {
        if (ModeManager.editMode == true)
        {
            BroadcastMessage("EnableMovement", SendMessageOptions.DontRequireReceiver);
            canvas.SetActive(false);

            if (gameObject.tag == "Turret")
            {
                ResetUI();
                WhatToDoTextChanger.text.text = "Move " + GetComponentInParent<Tower>().towerName + " somewhere...";
            }
            else
            {
                MouseHover.cursorSprite.enabled = true;
                MouseHover.cursorSprite.sprite = defaultCursorSprite;
                WhatToDoTextChanger.text.text = "Move player somewhere...";
            }
        }


    }

    public void ResetUI()
    {
        MouseHover.cursorSprite.enabled = false;
        WhatToDoTextChanger.text.text = "";

        if (disableOnMove)
        {
            openPlayerUI(false);
        }
    }
}
