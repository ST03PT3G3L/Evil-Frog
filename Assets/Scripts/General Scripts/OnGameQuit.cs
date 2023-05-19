using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameQuit : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        foreach (GameObject tower in TowerPool.towerPool)
        {
            tower.GetComponent<Tower>().extraDamage = 0;
            tower.GetComponent<Tower>().extraRange = 0;
            tower.GetComponent<Tower>().extraFireRate = 0;
            tower.GetComponent<Tower>().extraPrice = 0;
        }
    }
}
