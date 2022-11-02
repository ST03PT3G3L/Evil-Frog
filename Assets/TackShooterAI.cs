using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackShooterAI : MonoBehaviour
{
    [SerializeField] private int totalBullets;
    private Tower tower;
    private Transform target;
    private float fireCountdown;
    private List<GameObject> modules = new List<GameObject>();
    private void Start()
    {
        tower = GetComponentInParent<Tower>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;

        transform.up = -(target.position - transform.position);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / tower.fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        float rotation = 360;
        float interval;
        List<GameObject> bullets = new List<GameObject>();

        for(int i = 0; i < totalBullets; i++)
        {
            bullets.Add(tower.bulletPrefab);
        }

        interval = 360 / bullets.Count;

        foreach(GameObject bullet in bullets)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 360f));
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 5);
            rotation -= interval;
            Destroy(bullet, 5f);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= tower.range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
