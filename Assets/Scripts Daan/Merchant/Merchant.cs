using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] Currency curreny;

    [SerializeField] GameObject tower;
    [SerializeField] Transform pos;
    public void BuyTower(int price)
    {
        if(curreny.money >= price)
        {
            curreny.loseMoney(price);
            InstantiateTower();
        }
    }

    private void InstantiateTower()
    {
        GameObject newTower = Instantiate(tower, pos.position, Quaternion.identity);
    }
}
