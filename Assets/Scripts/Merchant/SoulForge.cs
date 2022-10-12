using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulForge : MonoBehaviour
{
    [SerializeField] private List<GameObject> towersTheForgeSells;

    [SerializeField] ManageSoulForgeUI uiManager;
    [SerializeField] Currency curreny;
    [SerializeField] Transform pos;

    private void Start()
    {
        uiManager.updateUI(towersTheForgeSells);
    }

    public void BuyItem(GameObject preFab)
    {
        Tower tower = preFab.GetComponent<Tower>();
        tower.UpdateData();

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
