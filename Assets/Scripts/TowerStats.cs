using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] float range;
    [SerializeField] float damage;
    [SerializeField] float price;
    public float moneySpent;

    public float Price
    {
        get { return price; }
        set { price = value; }
    }

    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float Range
    {
        get { return range; }
        set { range = value; }
    }
}
