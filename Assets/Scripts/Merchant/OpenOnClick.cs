using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnClick : MonoBehaviour
{
    [SerializeField] public ManageUI manager;
    [SerializeField] public Canvas canvas;

    private void OnMouseDown()
    {
        manager.ActivateUI(canvas);
        Debug.Log(1);
    }
}
