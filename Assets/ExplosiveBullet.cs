using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed;
    [SerializeField] GameObject explosionEffect;
    float damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Debug.Log("EXPLOSION HIT!");
        GameObject explosion = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        explosion.GetComponent<ExplosionEffect>().SetDamage(damage);
        Destroy(gameObject);
        Destroy(explosion, 5f);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
