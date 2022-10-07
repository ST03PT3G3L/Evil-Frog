using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowerData : ScriptableObject
{
    [SerializeField] public float fireRate_;
    [SerializeField] public float range_;
    [SerializeField] public float damage_;
    [SerializeField] public float price_;
    [SerializeField] public GameObject bulletPrefab_;
}
