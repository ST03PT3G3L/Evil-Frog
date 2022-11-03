using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private ManageUI uiManager;
    [SerializeField] private EnableOnChoice buttonDisabler;
    [SerializeField] private GameObject itemChest;
    [SerializeField] public List<string> possibleRewards;
    private ButtonUI ui;
    private string[] chosenRewards = new string[2];
    private string reward = "";

    private void Start()
    {
        ui = GetComponent<ButtonUI>();
        SetupChoice();
    }

    public void SetupChoice()
    {
        List<string> newList = possibleRewards;
        for (int i = 0; i < 2; i++)
        {
            int rndm = Random.Range(0, newList.Count);

            if (ui != null)
            {
                ui.setText(newList[rndm], i);
            }
            chosenRewards[i] = newList[rndm];
        }
    }

    public void chooseReward(int buttonNumber)
    {
        reward = chosenRewards[buttonNumber];
    }

    public void StartWave()
    {
        uiManager.SwitchUIForModes(false);

    }

    public void EndWave()
    {
        uiManager.SwitchUIForModes(true);
        buttonDisabler.enableOrDisableButton(false);
        SetupChoice();

        GameObject currencyHandler = GameObject.FindGameObjectWithTag("CurrencyHandler");
        switch (reward)
        {
            case "Money":
                currencyHandler.GetComponent<Currency>().EarnMoney(10);
                break;
            case "Souls":
                currencyHandler.GetComponent<Currency>().EarnSouls(10);
                break;
            case "Item":
                Instantiate(itemChest, new Vector3(18, 5, 0), Quaternion.identity);
                break;
        }
        
    }
}
