using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] public string name_;
    [SerializeField] public float price_;
    [SerializeField] public string description_;
    [SerializeField] public Sprite sprite_;
}
