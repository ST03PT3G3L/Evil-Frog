using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject tower;

    private void Awake()
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            tower.GetComponent<Tower>().AddModule(eventData.pointerDrag.gameObject);
            eventData.pointerDrag.GetComponent<ModuleDragDop>().inSpot = true;
            eventData.pointerDrag.GetComponent<ModuleDragDop>().Tower = tower;
        }
    }
}
