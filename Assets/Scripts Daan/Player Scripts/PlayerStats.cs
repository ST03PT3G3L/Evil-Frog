using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float fireRate;
    [SerializeField] float range;
    [SerializeField] float walkRange;
    [SerializeField] float damage;
    [SerializeField] float speed;


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

    public float WalkRange
    {
        get { return walkRange + range; }
        set { walkRange = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
