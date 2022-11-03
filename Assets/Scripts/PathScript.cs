using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    [SerializeField] public Directions direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Checker")
        collision.GetComponent<EnemyMovement>().Movement(direction);
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
