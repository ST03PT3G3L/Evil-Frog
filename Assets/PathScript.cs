using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    [SerializeField] public Directions direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyMovement>().Movement(direction);
    }
}
