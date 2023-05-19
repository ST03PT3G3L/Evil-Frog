using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageSoulForgeUI : MonoBehaviour
{
    [SerializeField] public List<Button> buttons;
    [SerializeField] public List<TextMeshProUGUI> buyTexts;
    [SerializeField] public List<TextMeshProUGUI> priceTexts;
    [SerializeField] public List<Image> sprites;
    [SerializeField] public List<TextMeshProUGUI> descriptions;

    public void updateUI(GameObject[] towersObjects)
    {
        int i = 0;
        foreach (GameObject towerObject in towersObjects)
        {
            Tower tower = towerObject.GetComponent<Tower>();
            buyTexts[i].text = "Buy " + tower.towerName;

            priceTexts[i].text = tower.price + " souls";

            sprites[i].sprite = towerObject.GetComponentInChildren<SpriteRenderer>().sprite;

            descriptions[i].text = tower.description;
            i++;
        }
    }

    public void disableButton(int i)
    {
        buttons[i].interactable = false;
    }

    public void enableButtons()
    {
        buttons[0].interactable = true;
        buttons[1].interactable = true;
    }
}
