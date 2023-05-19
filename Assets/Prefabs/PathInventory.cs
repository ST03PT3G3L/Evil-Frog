using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PathInventory : MonoBehaviour
{
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private Transform pathParent;
    [SerializeField] private TextMeshProUGUI pathCountText;
    [HideInInspector] public GameObject currentPath;
    [SerializeField] private int pathsHolding = 0;

    public int PathsHolding
    {
        get { return pathsHolding; }
        set { pathsHolding = value; }
    }

    [SerializeField] private Image pathImage1;
    [SerializeField] private Image pathImage2;
    [SerializeField] private Image pathImage3;
    [SerializeField] private Image pathImage4;

    [SerializeField] private AudioSource storePathSource;

    [SerializeField] private GameObject infoText;

    private MouseHover hover;
    private void Start()
    {
        hover = GameObject.Find("HoverCheck").GetComponent<MouseHover>();
        UpdateText();
    }
    public void onClick()
    {
        if (currentPath == null)
        {
            gainPath();
        }
        else
        {
            storePath(currentPath);
        }

        UpdateText();
        infoText.SetActive(false);
    }

    public void storePath(GameObject path)
    {
        pathsHolding++;
        hover.isDraggingSomething = false;
        currentPath.GetComponentInParent<PathScript>().destroySelf();
        storePathSource.Play();
    }

    public void gainPath()
    {
        if(pathsHolding > 0)
        {
            pathsHolding--;
            GameObject newPath = Instantiate(pathPrefab, hover.transform.position, Quaternion.identity, pathParent);
            newPath.GetComponentInChildren<DragDrop>().PickUp();
        }
    }

    private void OnMouseEnter()
    {
        pathImage1.color = Color.red;
        pathImage2.color = Color.gray;
        pathImage3.color = Color.gray;
        pathImage4.color = Color.gray;
    }

    private void OnMouseExit()
    {
        pathImage1.color = Color.white;
        pathImage2.color = Color.white;
        pathImage3.color = Color.white;
        pathImage4.color = Color.white;
    }

    public void UpdateText()
    {
        pathCountText.text = pathsHolding.ToString();
    }
}
