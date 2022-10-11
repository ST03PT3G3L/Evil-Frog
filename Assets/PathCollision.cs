using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Path")
        {
            Debug.Log("Path Connected");
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
