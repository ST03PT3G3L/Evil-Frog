using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject currencyHandler;

    private void Start()
    {
        currencyHandler = GameObject.FindGameObjectWithTag("CurrencyHandler");
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            currencyHandler.GetComponent<Currency>().EarnSouls(1);
            Destroy(gameObject);
        }
    }
}
