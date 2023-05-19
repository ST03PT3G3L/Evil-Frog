using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Enemy enemy;
    private GameObject currencyHandler;

    [SerializeField] GameObject healthBar;
    [SerializeField] Slider healthSlider;

    public float maxHp;

    public bool freeze;
    private bool frozen = false;

    public bool fire;
    private bool onFire = false;

    public bool poison;
    public bool hurt;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        currencyHandler = GameObject.FindGameObjectWithTag("CurrencyHandler");
    }


    public void ReceiveDamage(float damage)
    {
        if(maxHp == 0)
        {
            maxHp = enemy.HP;
        }

        float multiplier = InflictStatus();
        enemy.HP -= damage * multiplier;

        if (healthBar.activeSelf == false)
        {
            healthBar.SetActive(true);
        }

        healthSlider.value = CalculateHealth();
        StartCoroutine(TakeDamage());

        if (enemy.HP <= 0)
        {
            currencyHandler.GetComponent<Currency>().EarnSouls(1);
            Destroy(gameObject);
        }
    }

    private float InflictStatus()
    {
        float multiplier = 1;
        if(freeze)
        {
            if (!frozen)
            {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * .67f;
                enemy.speed = enemy.speed * 0.9f;
                frozen = true;
            }
            multiplier = multiplier * .75f;
        }

        if(fire)
        {
            if(!onFire)
            {
                onFire = true;
                Color burning = new Color(215, 158, 72, 255);
                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(Burning());
            }
            multiplier = multiplier * 1.1f;
        }


        return multiplier;
    }

    IEnumerator Burning()
    {
        Debug.Log("Burn");
        onFire = true;
        while(onFire)
        {
            enemy.HP -= .5f;

            if (enemy.HP <= 0)
            {
                currencyHandler.GetComponent<Currency>().EarnSouls(1);
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator TakeDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    float CalculateHealth()
    {
        Debug.Log(enemy.HP);
        return enemy.HP / maxHp;
    }
}
