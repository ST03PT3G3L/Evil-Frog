using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Directions directions;
    [SerializeField] GameObject checkerPrefab;

    private float moveX;
    private float moveY;
    [SerializeField] bool waveOngoing = false;

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }*/
    }

    private void Start()
    {
        StartCoroutine(SpawnChecker());
    }

    IEnumerator SpawnChecker()
    {
        while (!waveOngoing)
        {
            Instantiate(checkerPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    public void EndWave()
    {
        waveOngoing = false;
        StartCoroutine(SpawnChecker());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetDirection();
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        }
        else if(collision.tag == "Checker")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX*10, moveY*10);
        }
    }

    public void StartWave()
    {
        waveOngoing = true;
    }

    private void GetDirection()
    {
        switch (directions)
        {
            case Directions.Up:
                moveY = 5;
                moveX = 0;
                break;
            case Directions.Left:
                moveY = 0;
                moveX = -5;
                break;
            case Directions.Right:
                moveY = 0;
                moveX = 5;
                break;
        }
    }
}
