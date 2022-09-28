using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] public int money;

    [SerializeField] TextMeshProUGUI soulsText;
    [SerializeField] public int souls;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        moneyText.text = money.ToString();
        soulsText.text = souls.ToString();
    }

    public void EarnMoney(int moneyEarned)
    {
        money += moneyEarned;
        UpdateText();
    }

    public void EarnSouls(int soulsEarned)
    {
        souls += soulsEarned;
        UpdateText();
    }

    public void loseMoney(int moneyLost)
    {
        money -= moneyLost;
        UpdateText();
    }

    public void loseSouls(int soulsLost)
    {
        souls -= soulsLost;
        UpdateText();
    }
}

