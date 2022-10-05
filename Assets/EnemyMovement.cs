using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void Movement(Directions dir)
    {
        switch (dir)
        {
            case Directions.Up:
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, enemy.speed);
                break;
            case Directions.Down:
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemy.speed);
                break;
            case Directions.Right:
                GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.speed, 0);
                break;
            case Directions.Left:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-enemy.speed, 0);
                break;
        }
    }
}
