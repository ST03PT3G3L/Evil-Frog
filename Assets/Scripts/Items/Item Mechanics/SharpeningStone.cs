using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningStone : MonoBehaviour
{
    public float Amount;

    public void OnBuy()
    {
        foreach (GameObject tower in TowerPool.towerPool)
        {
            boostDamage(tower.GetComponent<Tower>());
        }

        foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Turret"))
        {
            boostDamage(tower.GetComponent<Tower>());
        }
    }

    public void boostDamage(Tower tower)
    {
        if(tower != null)
        {
            if (tower.type != null)
            {
                if (tower.type == "sharp")
                {
                    tower.extraDamage += Amount;
                }
            }
            tower.UpdateData();
        }
    }
}
