using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData data;
    private MerchantItem item;
    public Sprite sprite;

    public string itemName;
    public float price;
    public string description;

    private void Start()
    {
        UpdateData();
    }

    public void UpdateData()
    {
        itemName = data.name_;
        price = data.price_;
        description = data.description_;
        sprite = data.sprite_;

        item = GetComponent<MerchantItem>();
        if (item != null)
        {
            item.price = this.price;
            item.itemName = this.itemName;
            item.description = this.description;
            item.type = "item";
            item.sprite = this.sprite;
        }
    }
}
