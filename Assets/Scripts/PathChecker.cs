using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChecker : MonoBehaviour
{
    [SerializeField] float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Lair")
        {
            Debug.Log("Path is complete!");
            Destroy(gameObject);
        }
        timer = 1f;
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(3, 7);
        timer = 1;
        StartCoroutine(TimerDown());
    }

    private void Update()
    {
    }

    IEnumerator TimerDown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }
        Debug.Log("Can't reach lair!");
        Destroy(gameObject);
    }
}
