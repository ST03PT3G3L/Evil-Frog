using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Module", menuName = "Module")]
public class ModuleData : ScriptableObject
{
    [SerializeField] public int moduleID_;
    [SerializeField] public ModuleType type_;
    [SerializeField] public string name_;
    [SerializeField] public float price_;
    [SerializeField] public string description_;

}
