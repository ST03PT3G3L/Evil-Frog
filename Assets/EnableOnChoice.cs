using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableOnChoice : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        enableOrDisableButton(false);
    }

    public void enableOrDisableButton(bool enable)
    {
        button.interactable = enable;
    }
}
