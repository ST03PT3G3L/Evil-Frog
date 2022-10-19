using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    float damage;
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
            collision.GetComponent<EnemyHealth>().ReceiveDamage(damage);
        }
    }
}
