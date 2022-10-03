using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] Currency curreny;

    [SerializeField] GameObject tower;
    [SerializeField] Transform pos;
    public void BuyTower()
    {
        float price = tower.gameObject.GetComponentInChildren<TowerStats>().Price;

        if(curreny.souls >= price)
        {
            curreny.loseSouls((int)price);
            InstantiateTower((int)price);
        }
    }

    private void InstantiateTower(int price)
    {
        GameObject newTower = Instantiate(tower, pos.position, Quaternion.identity);
    }

    public void BuyItem(int price)
    {
        if (curreny.money >= price)
        {
            curreny.loseMoney(price);
            givePlayerAttackSpeed();
        }
    }

    private void givePlayerAttackSpeed()
    {
        pos.GetComponent<TowerStats>().FireRate += 1;
    }
}
