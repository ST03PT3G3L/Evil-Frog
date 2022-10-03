using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    [SerializeField] public float fireRate;
    [SerializeField] float range;
    [SerializeField] float damage;

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
