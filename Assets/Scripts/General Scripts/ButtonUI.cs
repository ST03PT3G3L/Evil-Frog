using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonUI : MonoBehaviour
{
    public Button[] buttons = new Button[2];
    
    public void setText(string txt, int i)
    {
        buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = txt;
    }
}
