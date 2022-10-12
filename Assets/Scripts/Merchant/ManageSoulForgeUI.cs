using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageSoulForgeUI : MonoBehaviour
{
    [SerializeField] public List<TextMeshProUGUI> buyTexts;
    [SerializeField] public List<TextMeshProUGUI> priceTexts;

    public void updateUI(List<GameObject> towersObjects)
    {
        int i = 0;
        foreach (GameObject towerObject in towersObjects)
        {
            Tower tower = towerObject.GetComponent<Tower>();
            buyTexts[i].text = "Buy " + tower.towerName;

            priceTexts[i].text = tower.price + " souls";
            i++;
        }
    }
}
