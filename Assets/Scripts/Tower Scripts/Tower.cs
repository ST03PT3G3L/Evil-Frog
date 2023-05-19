using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] public TowerData data;
    [SerializeField] private Transform rangeOutline;

    public string towerName;
    public string description;
    public float fireRate;
    public float range;
    public float damage;
    public float price;

    public float extraFireRate = 0;
    public float extraRange = 0;
    public float extraDamage = 0;
    public float extraPrice = 0;

    public GameObject bulletPrefab;
    public float moneySpent;
    public string type;

    public List<GameObject> modules = new List<GameObject>();

    void Start()
    {
        UpdateData();
        moneySpent = 0;
    }

    public void UpdateData()
    {
        towerName = data.name_;
        fireRate = data.fireRate_ + extraFireRate;
        range = data.range_ + extraRange;
        damage = data.damage_ + extraDamage;
        price = data.price_ + extraPrice;
        bulletPrefab = data.bulletPrefab_;
        type = data.type_;
        description = data.description_;
        rangeOutline.localScale = new Vector3(range / 2 * .1f, range / 2 * .1f, 1);
    }

    public void AddModule(GameObject module)
    {
        modules.Add(module);
    }

    public void RemoveModule(GameObject module)
    {
        modules.Remove(module);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
