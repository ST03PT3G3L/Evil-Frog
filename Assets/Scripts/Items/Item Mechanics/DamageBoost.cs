using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : MonoBehaviour
{
    public float Amount;
    public PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        if(playerStats == null)
        {
            Debug.Log("No Player found!");
        }

        OnBuy();
    }

    public void OnBuy()
    {
        playerStats.Damage += Amount;
        Debug.Log("Boost");
    }

}
