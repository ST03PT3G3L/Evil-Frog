using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageUI : MonoBehaviour
{
    [SerializeField] private Canvas mainUI;
    [SerializeField] private Canvas editModeUI;
    [SerializeField] private Canvas merchantUI;
    [SerializeField] private Canvas soulsForgeUI;
    [SerializeField] private Canvas itemUI;

    private void Start()
    {
        ActivateUI(mainUI);
        editModeUI.enabled = true;
    }

    public void ActivateUI(Canvas ui)
    {
        merchantUI.enabled = false;
        soulsForgeUI.enabled = false;
        itemUI.enabled = false;

        ui.enabled = true;
    }

    public void SwitchUIForModes(bool inEditMode)
    {
        editModeUI.enabled = inEditMode;
    }
}
