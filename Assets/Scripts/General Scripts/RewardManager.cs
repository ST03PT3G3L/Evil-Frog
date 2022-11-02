using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    string reward = "";

    [SerializeField] private GameObject choice1;
    [SerializeField] private GameObject choice2;
    [SerializeField] private string[] choices;
    public ModuleData[] moduleStats;
    public GameObject modulePrefab;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChooseModule();
            EndWave();
        }
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
        }
    }
}
