using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerUp : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        }
    }
}
