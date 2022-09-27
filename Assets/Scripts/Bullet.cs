using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Transform target;
    [SerializeField] float speed;
    float damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Debug.Log("HIT ON ENEMY!");
        target.GetComponent<EnemyHealth>().ReceiveDamage(damage);
        Destroy(gameObject);
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
