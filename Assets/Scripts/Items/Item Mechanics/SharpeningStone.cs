using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningStone : MonoBehaviour
{
    public float Amount;
    [SerializeField] List<Tower> towers;

    private void Start()
    {
        OnBuy();
    }

    public void OnBuy()
    {
        int i = 0;
        foreach (Tower tower in towers)
        {
            boostDamage(tower);
        }

        foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Turret"))
        {
            boostDamage(tower.GetComponent<Tower>());
        }
    }

    public void boostDamage(Tower tower)
    {
        if (tower.type == "sharp")
        {
            tower.damage += Amount;
        }
    }
}
