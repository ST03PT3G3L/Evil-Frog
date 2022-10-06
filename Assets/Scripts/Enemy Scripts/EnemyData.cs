using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string name_;
    public float maxHP_;
    public float speed_;
    public float worth_;

    //public SpriteRenderer sprite;
}