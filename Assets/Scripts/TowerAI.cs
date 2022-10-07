using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private Tower tower;
    private Transform target;
    private float fireCountdown;
    private void Start()
    {
        tower = GetComponentInParent<Tower>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;

        transform.right = target.position - transform.position;

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / tower.fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(tower.bulletPrefab, transform.position, transform.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.SetDamage(tower.damage);
            bullet.Seek(target);
        }
        Debug.Log("Shoot");
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= tower.range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


}
