using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUpgrades : MonoBehaviour
{
    [SerializeField] Canvas upgradeCanvas;
    [SerializeField] Canvas moduleInventory;

    [SerializeField] TextMeshProUGUI upgrade1Text;
    [SerializeField] TextMeshProUGUI upgrade2Text;

    [SerializeField] TextMeshProUGUI upgrade1CostText;
    [SerializeField] TextMeshProUGUI upgrade2CostText;

    public TextMeshProUGUI upgrade1BoughtText;
    public TextMeshProUGUI upgrade2BoughtText;

    public float upgrade1Bought;
    public float upgrade2Bought;

    private Tower stats;

    public bool selected = false;

    [SerializeField] AudioSource upgradeSource;

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

  /*  private void OnMouseOver()
    {
        if(ModeManager.editMode)
        if(Input.GetMouseButtonDown(1))
        {
            GameObject[] Towers = GameObject.FindGameObjectsWithTag("Turret");
            Debug.Log(Towers.Length);
            foreach(GameObject tower in Towers)
            {
                TowerUpgrades towerup = tower.gameObject.GetComponent<TowerUpgrades>();
                if(towerup != null)
                {
                   if(towerup.selected)
                    {
                        towerup.CloseCanvas();
                    }
                }

            }
            OpenCanvas();
        }
    }

    private void OpenCanvas()
    {
        selected = true;
        upgradeCanvas.GetComponent<Canvas>().enabled = true;
        moduleInventory.GetComponent<Canvas>().enabled = true;
        GetComponentInParent<Range>().enabled = true;
        GetComponentInParent<LineRenderer>().enabled = true;
    } */

    public void DisableRange()
    {
        GetComponentInParent<Range>().enabled = false;
        GetComponentInParent<LineRenderer>().enabled = false;
    }

    public void CloseCanvas()
    {
        DisableRange();
        upgradeCanvas.GetComponent<Canvas>().enabled = false;
        moduleInventory.GetComponent<Canvas>().enabled = false;
        selected = false;
    }

    public void BoughtUpgrade1()
    {
        upgrade1Bought++;
        upgrade1BoughtText.text = upgrade1Bought.ToString();
    }

    public void BoughtUpgrade2()
    {
        upgrade2Bought++;
        upgrade2BoughtText.text = upgrade2Bought.ToString();
    }

    public void BuyTopUpgrade()
    {
        switch (upgrade1Name)
        {
            case "+Damage":
                if (currencyHandler.GetComponent<Currency>().souls >= upgrade1Cost)
                {

                    stats.moneySpent += upgrade1Cost;
                    Debug.Log("Succes");
                    currencyHandler.GetComponent<Currency>().loseSouls(upgrade1Cost);
                    stats.extraDamage += 0.5f;
                    stats.UpdateData();
                    BoughtUpgrade1();
                    upgradeSource.Play();
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
            case "+FireRate":
                if (currencyHandler.GetComponent<Currency>().souls >= upgrade2Cost)
                {

                    stats.moneySpent += upgrade1Cost;
                    currencyHandler.GetComponent<Currency>().loseSouls(upgrade2Cost);
                    stats.extraFireRate += 1;
                    stats.UpdateData();
                    BoughtUpgrade2();
                    upgradeSource.Play();
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
        upgrade1Text.text = upgrade1Name;
        upgrade1CostText.text = upgrade1Cost.ToString() + " souls";

        Upgrade upgrade2 = upgrades[1];
        upgrade2Name = upgrade2.name;
        upgrade2Cost = upgrade2.cost;
        upgrade2Text.text = upgrade2Name;
        upgrade2CostText.text = upgrade2Cost.ToString() + " souls";
    }
}
