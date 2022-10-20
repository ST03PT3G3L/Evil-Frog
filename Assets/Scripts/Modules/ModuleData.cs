using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleData : ScriptableObject
{
    [SerializeField] public int moduleID_;
    [SerializeField] public string name_;
    [SerializeField] public float price_;
    [SerializeField] public string description_;

}
