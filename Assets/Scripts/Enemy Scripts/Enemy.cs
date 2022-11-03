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
    public string type;

    private float timeAlive;
    public float distanceToEnd;
    private void Start()
    {
        updateData();
        timeAlive = 0;
        distanceToEnd = 0;
    }

    private void updateData()
    {
        enemyName = data.name_;
        HP = data.maxHP_;
        speed = data.speed_;
        worth = data.worth_;
        type = data.type_;
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        distanceToEnd = timeAlive / speed;
    }
}



