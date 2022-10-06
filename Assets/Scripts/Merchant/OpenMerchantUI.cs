using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMerchantUI : MonoBehaviour
{
    [SerializeField] private Canvas merchantUI;
    [SerializeField] private Canvas mainUI;
    [SerializeField] private Canvas soulsForgeUI;

    private void Start()
    {
        ActivateUI(mainUI);
    }

    public void ActivateUI(Canvas ui)
    {
        merchantUI.enabled = false;
        mainUI.enabled = false;
        soulsForgeUI.enabled = false;

        ui.enabled = true;
    }
}
