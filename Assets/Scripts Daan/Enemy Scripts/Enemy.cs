using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyData data;

    public string enemyName;
    public float HP;
    public float speed;
    public float worth;
    private void Start()
    {
        updateData();
    }
    private void updateData()
    {
        enemyName = data.name_;
        HP = data.maxHP_;
        speed = data.speed_;
        worth = data.worth_;
    }
}



