using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private ManageUI uiManager;
    [SerializeField] private EnableOnChoice buttonDisabler;
    string reward = "";

    public void ChooseMoney()
    {
        reward = "Money";
    }

    public void ChooseSouls()
    {
        reward = "Souls";
    }

    public void StartWave()
    {
        uiManager.SwitchUIForModes(false);

    }

    public void EndWave()
    {
        uiManager.SwitchUIForModes(true);
        buttonDisabler.enableOrDisableButton(false);


        GameObject currencyHandler = GameObject.FindGameObjectWithTag("CurrencyHandler");
        switch (reward)
        {
            case "Money":
                currencyHandler.GetComponent<Currency>().EarnMoney(10);
                break;
            case "Souls":
                currencyHandler.GetComponent<Currency>().EarnSouls(10);
                break;
        }
        
    }
}
