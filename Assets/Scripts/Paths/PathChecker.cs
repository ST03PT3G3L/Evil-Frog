using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChecker : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] bool onPath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Lair")
        {
            Debug.Log("Path is complete!");
            Destroy(gameObject);
        }
        else timer++;

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
        yield return new WaitForSeconds(.1f);
        timer -= 1;
        CheckTimer();
        //Debug.Log("TickTock");
    }

    private void CheckTimer()
    {
        StartCoroutine(TimerDown());
        if (timer <= 0)
        {
            //Debug.Log("Can't reach Lair!");
            Destroy(gameObject);
        }
    }
}
