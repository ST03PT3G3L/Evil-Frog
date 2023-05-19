using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMastery : MonoBehaviour
{
    public float extraDamage;
    public float extraRange;
    public float extraAttackSpeed;

    private void Start()
    {

    }

    public void OnBuy()
    {
        foreach (GameObject tower in TowerPool.towerPool)
        {
            boostStats(tower.GetComponent<Tower>());
        }

        foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Turret"))
        {
            boostStats(tower.GetComponent<Tower>());
        }
    } 

    public void boostStats(Tower tower)
    {
        if (tower != null)
        {
            if (tower.type != null)
            {
                if (tower.type == "explosive")
                {
                    tower.extraDamage += extraDamage;
                    tower.extraRange += extraRange;
                    tower.extraFireRate += extraAttackSpeed;
                }
            }
            tower.UpdateData();
        }
    }
}
