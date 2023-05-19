using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardChoiceManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] RewardManager rewardManager;

    public void SetMoney()
    {
        buttonText.text = "Money";

        gameObject.GetComponent<Button>().onClick.RemoveListener(Money_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Souls_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Module_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Item_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Paths_onClick);
        gameObject.GetComponent<Button>().onClick.AddListener(Money_onClick);
    }

    public void SetSouls()
    {
        buttonText.text = "Souls";

        gameObject.GetComponent<Button>().onClick.RemoveListener(Money_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Souls_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Module_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Item_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Paths_onClick);
        gameObject.GetComponent<Button>().onClick.AddListener(Souls_onClick);
    }

    public void SetModule()
    {
        buttonText.text = "Module";

        gameObject.GetComponent<Button>().onClick.RemoveListener(Money_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Souls_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Module_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Item_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Paths_onClick);
        gameObject.GetComponent<Button>().onClick.AddListener(Module_onClick);
    }

    public void SetItem()
    {
        buttonText.text = "Item";

        gameObject.GetComponent<Button>().onClick.RemoveListener(Money_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Souls_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Item_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Module_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Paths_onClick);

        gameObject.GetComponent<Button>().onClick.AddListener(Item_onClick);
    }

    public void SetPaths()
    {
        buttonText.text = "Paths";

        gameObject.GetComponent<Button>().onClick.RemoveListener(Money_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Souls_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Item_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Module_onClick);
        gameObject.GetComponent<Button>().onClick.RemoveListener(Paths_onClick);

        gameObject.GetComponent<Button>().onClick.AddListener(Paths_onClick);
    }

    void Money_onClick()
    {
        Debug.Log("Money");
        rewardManager.ChooseMoney();
    }

    void Souls_onClick()
    {
        Debug.Log("Souls");
        rewardManager.ChooseSouls();
    }

    void Module_onClick()
    {
        Debug.Log("Module");
        rewardManager.ChooseModule();
    }

    void Item_onClick()
    {
        Debug.Log("Item");
        rewardManager.ChooseItem();
    }

    void Paths_onClick()
    {
        rewardManager.ChoosePaths();
    }
}
