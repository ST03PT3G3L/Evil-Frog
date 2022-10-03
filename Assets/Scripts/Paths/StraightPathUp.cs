using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPathUp : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
       else if(collision.tag == "Checker")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50);
        }
    }

}
