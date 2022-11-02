using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModuleDragDop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform recTransform;
    private CanvasGroup canvasGroup;

    public GameObject Tower;

    [SerializeField] private Canvas canvas;

    Vector2 originalPos;
    public bool inSpot;

    private void Awake()
    {
        GetComponent<Animator>().SetBool("Spawned", true);
        recTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        originalPos = recTransform.anchoredPosition;
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("Spawned", false);
        inSpot = false;
        canvasGroup.alpha = .75f;
        canvasGroup.blocksRaycasts = false;
        if (Tower != null)
        {
            Tower.GetComponent<Tower>().RemoveModule(gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        recTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if(!inSpot)
        {
            recTransform.anchoredPosition = originalPos;
            if (Tower != null)
            {
                Tower.GetComponent<Tower>().AddModule(gameObject);
            }
        }
    }
}
