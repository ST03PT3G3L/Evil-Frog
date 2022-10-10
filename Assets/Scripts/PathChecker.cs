using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChecker : MonoBehaviour
{
    [SerializeField] float timer;
    bool onPath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lair")
        {
            Debug.Log("Path is complete!");
            Destroy(gameObject);
        }
        timer++;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Path")
        {
            onPath = true;
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Path")
        {
            onPath = false;
        }
    }*/

    private void Start()
    {
        timer = 1;
        StartCoroutine(TimerDown());
    }

    private void Update()
    { 
        if(timer == 0)
        {
        }
    }

    IEnumerator TimerDown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(.075f);
            timer -= 1;
        }
        Debug.Log("Can't reach lair!");
        Destroy(gameObject);
    }
}
