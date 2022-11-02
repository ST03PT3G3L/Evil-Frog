using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleStats : MonoBehaviour
{
    [SerializeField] public ModuleData data;

    public int moduleId;
    public string moduleName;
    public ModuleType type;
    public float price;
    public string description;

    [SerializeField] Image image;
    [SerializeField] Sprite iceSprite;
    [SerializeField] Sprite fireSprite;

    void Start()
    {
        UpdateData();
    }

    public void UpdateData()
    {
        moduleId = data.moduleID_;
        moduleName = data.name_;
        type = data.type_;
        price = data.price_;
        description = data.description_;

        if(type == ModuleType.Freeze)
        {
            image.sprite = iceSprite;
        }

        if(type == ModuleType.Fire)
        {
            image.sprite = fireSprite;
        }
    }
}
