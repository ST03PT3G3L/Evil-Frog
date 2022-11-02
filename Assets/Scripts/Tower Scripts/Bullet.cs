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
    [SerializeField] public ModuleType attribute1;
    [SerializeField] public ModuleType attribute2;

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
                SetStatus(target);
                target.GetComponent<EnemyHealth>().ReceiveDamage(damage);
                Destroy(gameObject);
                break;
            case BulletType.ExplosiveBullet:
                GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
                explosion.GetComponent<ExplosionEffect>().SetDamage(damage);
                explosion.GetComponent<ExplosionEffect>().attribute1 = attribute1;
                Destroy(gameObject);
                Destroy(explosion, 5f);
                break;
        }
        
    }

    private void SetStatus(Transform enemy)
    {
        EnemyHealth target = enemy.GetComponent<EnemyHealth>();
        switch(attribute1)
        {
            case ModuleType.Null:
                break;
            case ModuleType.Freeze:
                target.freeze = true;
                break;
            case ModuleType.Fire:
                target.fire = true;
                break;
            case ModuleType.Poison:
                target.poison = true;
                break;
            case ModuleType.Hurt:
                target.hurt = true;
                break;
        }

        switch(attribute2)
        {
            case ModuleType.Null:
                break;
            case ModuleType.Freeze:
                target.freeze = true;
                break;
            case ModuleType.Fire:
                target.fire = true;
                break;
            case ModuleType.Poison:
                target.poison = true;
                break;
            case ModuleType.Hurt:
                target.hurt = true;
                break;
        }
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
