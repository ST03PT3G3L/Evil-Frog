using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Transform target;
    [SerializeField] float speed;
    float damage;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] BulletType type;

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
        switch(type)
        {
            case BulletType.NormalBullet:
                target.GetComponent<EnemyHealth>().ReceiveDamage(damage);
                Destroy(gameObject);
                break;
            case BulletType.ExplosiveBullet:
                GameObject explosion = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
                explosion.GetComponent<ExplosionEffect>().SetDamage(damage);
                Destroy(gameObject);
                Destroy(explosion, 5f);
                break;
        }
        
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
