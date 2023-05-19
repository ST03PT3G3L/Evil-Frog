using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    string reward = "";

    [SerializeField] private GameObject choice1;
    [SerializeField] private GameObject choice2;
    [SerializeField] private string[] choices;
    [SerializeField] private GameObject itemChest;
    [SerializeField] private GameObject pathInventory;
    public ModuleData[] moduleStats;
    public GameObject modulePrefab;

    private void Start()
    {
        RewardChoiceManager choiceM1 = choice1.GetComponent<RewardChoiceManager>();
        RewardChoiceManager choiceM2 = choice2.GetComponent<RewardChoiceManager>();

        choiceM1.GetComponent<RewardChoiceManager>().SetMoney();
        choiceM2.GetComponent<RewardChoiceManager>().SetSouls();
    }

    public void ChooseMoney()
    {
        reward = "Money";
    }

    public void ChooseSouls()
    {
        reward = "Souls";
    }

    public void ChooseModule()
    {
        reward = "Module";
    }

    public void ChooseItem()
    {
        reward = "Item";
    }

    public void ChoosePaths()
    {
        reward = "Paths";
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
            case "Module":
                int count = moduleStats.Length;
                int rnd = Random.Range(0, count);
                ModuleData data = moduleStats[rnd];
                GameObject module = Instantiate(modulePrefab, transform.position, transform.rotation);
                module.transform.SetParent(this.transform);
                module.GetComponent<ModuleStats>().data = data;
                break;
            case "Item":
                Instantiate(itemChest, new Vector3(-2, 7, 0), Quaternion.identity);
                break;
            case "Paths":
                for(int i = 0; i < 2; i++)
                {
                    pathInventory.GetComponent<PathInventory>().PathsHolding += 1;
                }
                pathInventory.GetComponent<PathInventory>().UpdateText();
                break;
        }
        RandomizeRewards();
        
    }

    private void RandomizeRewards()
    {
        RewardChoiceManager choiceM1 = choice1.GetComponent<RewardChoiceManager>();
        RewardChoiceManager choiceM2 = choice2.GetComponent<RewardChoiceManager>();

        int range = choices.Length;
        int rnd = Random.Range(0, range);
        string choice = choices[rnd];

        Debug.Log(choice);

        switch(choice)
        {
            case "Coins":
                choiceM1.GetComponent<RewardChoiceManager>().SetMoney();
                break;
            case "Souls":
                choiceM1.GetComponent<RewardChoiceManager>().SetSouls();
                break;
            case "Module":
                choiceM1.GetComponent<RewardChoiceManager>().SetModule();
                break;
            case "Item":
                choiceM1.GetComponent<RewardChoiceManager>().SetItem();
                break;
            case "Paths":
                choiceM1.GetComponent<RewardChoiceManager>().SetPaths();
                break;
        }

        int rnd2 = -1;
        while (rnd == rnd2 || rnd2 < 0)
        {
            rnd2 = Random.Range(0, range);
        }

        choice = choices[rnd2];

        switch (choice)
        {
            case "Coins":
                choiceM2.GetComponent<RewardChoiceManager>().SetMoney();
                break;
            case "Souls":
                choiceM2.GetComponent<RewardChoiceManager>().SetSouls();
                break;
            case "Module":
                choiceM2.GetComponent<RewardChoiceManager>().SetModule();
                break;
            case "Item":
                choiceM2.GetComponent<RewardChoiceManager>().SetItem();
                break;
            case "Paths":
                choiceM1.GetComponent<RewardChoiceManager>().SetPaths();
                break;
        }
    }
}
