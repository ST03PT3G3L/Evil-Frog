using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulForge : MonoBehaviour
{
    [SerializeField] Currency curreny;
    [SerializeField] Transform pos;
    public void BuyItem(GameObject preFab)
    {
        Tower tower = preFab.GetComponent<Tower>();
        tower.UpdateData();
        Debug.Log(tower.price);
        if (curreny.souls >= tower.price)
        {
            curreny.loseSouls((int)tower.price);
            InstantiateTower((int)tower.price, preFab);
        }
    }

    private void InstantiateTower(int price, GameObject tower)
    {
        GameObject newTower = Instantiate(tower.gameObject, pos.position, Quaternion.identity);
    } 
}
