using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] Currency curreny;
    [SerializeField] Transform pos;
    [SerializeField] ManageMerchantUI UI;

    [SerializeField] List<GameObject> sellableItems;
    MerchantItem[] itemsSelling = new MerchantItem[3];

    private void Start()
    {
        RandomizeShop();
        UI.updateUI(itemsSelling);
    }

    private void RandomizeShop()
    {
        for (int i = 0; i < 3; i++)
        {
            int rndm = Random.Range(0, sellableItems.Count);
            sellableItems[rndm].GetComponent<Item>().UpdateData();
            itemsSelling[i] = sellableItems[rndm].GetComponent<MerchantItem>();
            sellableItems.RemoveAt(rndm);
        }
    }

    public void Buy(int i)
    {
        if (curreny.money >= itemsSelling[i].price)
        {
            curreny.loseMoney((int)itemsSelling[i].price);
            Instantiate(itemsSelling[i].gameObject);
        }
    }
}

