using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPathRight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        }
        else if (collision.tag == "Checker")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);
        }
    }
}
