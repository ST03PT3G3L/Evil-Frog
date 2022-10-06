using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
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
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void EndWave()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

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
