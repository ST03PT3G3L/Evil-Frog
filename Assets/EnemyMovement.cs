using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;

    public void Movement(Directions dir)
    {
        switch (dir)
        {
            case Directions.Up:
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                break;
            case Directions.Down:
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                break;
            case Directions.Right:
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                break;
            case Directions.Left:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                break;
        }
    }
}
