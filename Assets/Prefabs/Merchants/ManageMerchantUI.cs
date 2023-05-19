using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageMerchantUI : MonoBehaviour
{
    [SerializeField] public List<TextMeshProUGUI> buyTexts;
    [SerializeField] public List<TextMeshProUGUI> priceTexts;

    [SerializeField] public List<TextMeshProUGUI> descriptions;
    [SerializeField] public List<Image> images;


    public void updateUI(MerchantItem[] items)
    {
        for (int i = 0; i < 3; i++)
        {
            items[i].GetComponent<Item>().UpdateData();
            buyTexts[i].text = items[i].itemName;
            priceTexts[i].text = items[i].price + " coins";
            descriptions[i].text = items[i].description;
            images[i].sprite = items[i].sprite;
        }
    }
}
