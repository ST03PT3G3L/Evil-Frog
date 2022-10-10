using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] public TowerData data;

    public float fireRate;
    public float range;
    public float damage;
    public float price;
    public GameObject bulletPrefab;
    public float moneySpent;
    void Start()
    {
        UpdateData();
    }

    public void UpdateData()
    {
        fireRate = data.fireRate_;
        range = data.range_;
        damage = data.damage_;
        price = data.price_;
        bulletPrefab = data.bulletPrefab_;
        moneySpent = 0;
        Debug.Log(data.price_);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
