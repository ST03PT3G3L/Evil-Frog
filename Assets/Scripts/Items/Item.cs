using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData data;

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
    }
}
