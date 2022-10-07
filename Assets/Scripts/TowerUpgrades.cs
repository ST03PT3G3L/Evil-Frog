using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUpgrades : MonoBehaviour
{
    [SerializeField] Canvas upgradeCanvas;

    [SerializeField] TextMeshProUGUI upgrade1Text;
    [SerializeField] TextMeshProUGUI upgrade2Text;

    private Tower stats;

    [System.Serializable]
    public class Upgrade
    {
        public string name;
        public int cost;
    }

    [SerializeField] public List<Upgrade> upgrades = new List<Upgrade>();

    GameObject currencyHandler;

    string upgrade1Name;
    int upgrade1Cost;

    string upgrade2Name;
    int upgrade2Cost;

    private void Start()
    {
        stats = GetComponentInParent<Tower>();
        currencyHandler = GameObject.FindGameObjectWithTag("CurrencyHandler");
        RandomizeUpgrade();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            upgradeCanvas.GetComponent<Canvas>().enabled = true;
            //Debug.Log("Right Clicked on Tower");
        }
    }

    public void CloseCanvas()
    {
        upgradeCanvas.GetComponent<Canvas>().enabled = false;
    }    

    public void BuyTopUpgrade()
    {
        switch (upgrade1Name)
        {
            case "Damage":
                if (currencyHandler.GetComponent<Currency>().souls >= upgrade1Cost)
                {

                    stats.moneySpent += upgrade1Cost;
                    Debug.Log("Succes");
                    currencyHandler.GetComponent<Currency>().loseSouls(upgrade1Cost);
                    stats.damage += 0.5f;
                }
                else
                {
                    Debug.Log("Not enough Souls!");
                }
                break;
            default:
                Debug.Log(upgrade1Name);
                break;
        }
        RandomizeUpgrade();
    }

    public void BuyBotUpgrade()
    {
        switch (upgrade2Name)
        {
            case "FireRate":
                if (currencyHandler.GetComponent<Currency>().souls >= upgrade2Cost)
                {

                    stats.moneySpent += upgrade1Cost;
                    currencyHandler.GetComponent<Currency>().loseSouls(upgrade2Cost);
                    stats.fireRate += 1;
                }
                else
                {
                    Debug.Log("Not enough Souls!");
                }
                break;
        }
        RandomizeUpgrade();
    }

    public void SellTower()
    {
        Debug.Log("a");
        float moneyBack = (stats.moneySpent + stats.price) * .75f;
        int money = (int)moneyBack;
        currencyHandler.GetComponent<Currency>().EarnSouls(money);
        Destroy(transform.parent.gameObject);
    }

    private void RandomizeUpgrade()
    {
        Upgrade upgrade1 = upgrades[0];
        upgrade1Name = upgrade1.name;
        upgrade1Cost = upgrade1.cost;
        upgrade1Text.text = upgrade1Name + "\nSouls: " + upgrade1Cost;

        Upgrade upgrade2 = upgrades[1];
        upgrade2Name = upgrade2.name;
        upgrade2Cost = upgrade2.cost;
        upgrade2Text.text = upgrade2Name + "\nSouls: " + upgrade2Cost;
    }
}
