using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] public PlayerStats stats;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator animator;

    private Targetting targetting;
    private GameObject target;
    private float fireCountdown;
    [HideInInspector]public Vector3 originPos;
    public State state;
    public bool facingRight = true;

    public enum State
    {
        Idle,
        Walking,
        Attacking,
        WalkingToEnemy
    }

    private void Start()
    {
        targetting = GetComponent<Targetting>();
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
        target = targetting.GetEnemy(stats.WalkRange, originPos);
        state = targetting.getState(target, stats.WalkRange, stats.Range, transform.position ,originPos);

        //If there are no close enough targets, stay idle
        if (state == State.Idle)
        {
            MoveTo(originPos);
            return;
        }

        //Automatically flip player when needed
        if(target != null)
        {
            if (target.transform.position.x < transform.position.x && facingRight)
            {
                Flip();
            }
            if (target.transform.position.x > transform.position.x && !facingRight)
            {
                Flip();
            }
        }


        //If the enemy is close enought but too far away to attack, move towards it
        if(state == State.WalkingToEnemy)
        {
            MoveTo(target.transform.position);
            return;
        }

        //If the enemy is in attack range, attack it
        if(state == State.Attacking)
        {

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
            bullet.Seek(target.transform);
        }
        Debug.Log("Shoot");
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

    public void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
