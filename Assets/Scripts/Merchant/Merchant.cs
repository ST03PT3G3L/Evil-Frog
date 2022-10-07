using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] Currency curreny;
    [SerializeField] Transform pos;
    public void BuyItem(Item item)
    {
        item.UpdateData();
        if (curreny.money >= item.price)
        {
            curreny.loseMoney((int)item.price);
        }
    }
}
