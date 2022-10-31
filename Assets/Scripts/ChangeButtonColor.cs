using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    [SerializeField] public List<Color> colors;
    private Button image;

    private void Start()
    {
        image = GetComponent<Button>();
    }

    public void changeToColor(int i)
    {
        if(i <= colors.Count)
        {
            //image.colors = colors[i];
        }
    }
}
