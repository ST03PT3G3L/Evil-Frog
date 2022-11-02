using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    float damage;
    public ModuleType attribute1;
    public ModuleType attribute2;
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            SetStatus(collision.transform);
            collision.GetComponent<EnemyHealth>().ReceiveDamage(damage);
        }
    }

    private void SetStatus(Transform enemy)
    {
        EnemyHealth target = enemy.GetComponent<EnemyHealth>();
        switch (attribute1)
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

        switch (attribute2)
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
}
