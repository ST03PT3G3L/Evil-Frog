using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    
    private Tower tower;
    private Transform target;
    private float fireCountdown;
    private List<GameObject> modules = new List<GameObject>();
    private Targetting targetting;
    [SerializeField] private Transform rotation;

    private void Start()
    {
        tower = GetComponentInParent<Tower>();
        targetting = GetComponent<Targetting>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;

        if(rotation != null)
        {
            rotation.up = -(target.position - rotation.position);
        }
        else
        {
            transform.up = -(target.position - transform.position);
        }


        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / tower.fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        modules = tower.modules;
        gameObject.GetComponent<AudioSource>().Play();
        GameObject BulletGO = (GameObject)Instantiate(tower.bulletPrefab, transform.position, transform.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            if(modules.Count >= 1)
            {
                int i = 0;
                foreach(GameObject m in modules)
                {
                    if(i == 0)
                    {
                        bullet.attribute1 = m.GetComponent<ModuleStats>().type;
                    }
                    if(i == 1)
                    {
                        bullet.attribute2 = m.GetComponent<ModuleStats>().type;
                    }
                    i++;
                }
            }
            bullet.SetDamage(tower.damage);
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject targetObject = targetting.GetEnemy(tower.range, transform.position);
        if(targetObject == null)
        {
            target = null;
            return;
        }
        target = targetObject.transform;
        


      /*  GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        } */
    } 
}
