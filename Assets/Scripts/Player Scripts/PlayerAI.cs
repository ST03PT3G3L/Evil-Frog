using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] public PlayerStats stats;
    [SerializeField] GameObject bulletPrefab;

    private Transform target;
    private float fireCountdown;
    [HideInInspector]public Vector3 originPos;
    public State state;

    public enum State
    {
        Idle,
        Walking,
        Attacking,
        WalkingToEnemy
    }

    private void Start()
    {
        originPos = transform.position;
    }

    private void Update()
    {
        if(fireCountdown > 0)
        {
            fireCountdown -= Time.deltaTime;
        }

        //The player should just walk when going to another location.
        if (state == State.Walking) return;

        //Look for targets
        state = UpdateTarget();

        //If there are no close enough targets, stay idle
        if (state == State.Idle)
        {
            MoveTo(originPos);
            return;
        }

        //If the enemy is close enought but too far away to attack, move towards it
        if(state == State.WalkingToEnemy)
        {
            MoveTo(target.position);
            return;
        }

        //If the enemy is in attack range, attack it
        if(state == State.Attacking)
        {
            transform.right = target.position - transform.position;

            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / stats.FireRate;
            }
        }
    }

    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetDamage(stats.Damage);
            bullet.Seek(target);
        }
        Debug.Log("Shoot");
    }

    private State UpdateTarget()
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

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;


                if (Vector2.Distance(originPos, target.position) <= stats.WalkRange)
                {
                    if (shortestDistance <= stats.Range)
                    {
                        return State.Attacking;
                    }
                    else
                    {
                        return State.WalkingToEnemy;
                    }
                }
        }    



        target = null;
        return State.Idle;
    }

    public void MoveTo(Vector3 pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, stats.Speed * Time.deltaTime);
    }

    public float getActualWalkRange()
    {
        return Mathf.Abs(stats.WalkRange - stats.Range);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.Range);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(originPos, stats.WalkRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(originPos, getActualWalkRange());
    }
}
