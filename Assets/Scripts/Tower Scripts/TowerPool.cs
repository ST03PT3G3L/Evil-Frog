using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerInstatiate;
    [HideInInspector] public static List<GameObject> towerPool;
    void Start()
    {
        towerPool = towerInstatiate;
    }

}
