using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMerchantUI : MonoBehaviour
{
    [SerializeField] private Canvas merchantUI;
    [SerializeField] private Canvas mainUI;

    private bool merchantUIIsActve = false;

    private void Start()
    {
        merchantUI.enabled = merchantUIIsActve;
    }

    public void ActivateMerchantUI()
    {
        merchantUIIsActve = !merchantUIIsActve;

        merchantUI.enabled = merchantUIIsActve;
        mainUI.enabled = !merchantUIIsActve;
    }
}
