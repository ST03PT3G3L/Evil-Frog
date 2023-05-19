using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : MonoBehaviour
{
    public float Amount;
    public PlayerStats playerStats;


    public void OnBuy()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        if (playerStats == null)
        {
            Debug.Log("No Player found!");
        }

        playerStats.Damage += Amount;
        Debug.Log("Boost");
    }

}
