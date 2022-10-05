using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //[SerializeField] GameObject enemyPrefab;
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

    public void SpawnEnemy(GameObject preFab)
    {
        Instantiate(preFab, transform.position, transform.rotation);
    }

    public void EndWave()
    {
        waveOngoing = false;
        StartCoroutine(SpawnChecker());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Checker")
        collision.GetComponent<EnemyMovement>().Movement(directions);
    }

    public void StartWave()
    {
        waveOngoing = true;
    }
}
