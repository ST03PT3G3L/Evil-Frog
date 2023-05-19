using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float damage;
    public float timeAlive;
    public ModuleType attribute1;
    public ModuleType attribute2;

    private void Start()
    {
        Destroy(gameObject, 6f);
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
