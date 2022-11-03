using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathInventory : MonoBehaviour
{
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private Transform pathParent;
    [SerializeField] private TextMeshProUGUI pathCountText;
    [HideInInspector] public GameObject currentPath;
    private int pathsHolding = 0;
    private MouseHover hover;
    private void Start()
    {
        hover = GameObject.Find("HoverCheck").GetComponent<MouseHover>();
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

        pathCountText.text = pathsHolding.ToString();
    }

    public void storePath(GameObject path)
    {
        pathsHolding++;
        hover.isDraggingSomething = false;
        currentPath.GetComponentInParent<PathScript>().destroySelf();
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
}
