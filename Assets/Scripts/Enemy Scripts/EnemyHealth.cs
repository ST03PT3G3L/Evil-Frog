using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy enemy;
    private GameObject currencyHandler;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        currencyHandler = GameObject.FindGameObjectWithTag("CurrencyHandler");
    }


    public void ReceiveDamage(float damage)
    {
        enemy.HP -= damage;

        if(enemy.HP <= 0)
        {
            currencyHandler.GetComponent<Currency>().EarnSouls(1);
            Destroy(gameObject);
        }
    }
}
