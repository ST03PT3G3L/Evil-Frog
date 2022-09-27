using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemySpawners;

    public int roundNumber = 0;
    public int space = 1;

    [System.Serializable]
    public class Round
    {
        public List<GameObject> enemies;
        public float spawnDelay;
    }

    public List<Round> rounds = new List<Round>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(InitiateNextRound());
        }
    }

    private void GetSpawners()
    {
        enemySpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    IEnumerator InitiateNextRound()
    {
        BroadcastMessage("StartWave");
        GetSpawners();

        Round round = rounds[roundNumber];

        int spawnersAmount = enemySpawners.Length;
        int i = 0;

        foreach (GameObject enemy in round.enemies)
        {
            StartCoroutine(SpawnEnemy(i));
            yield return new WaitForSeconds(1f);

            if(i < spawnersAmount - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }

        BroadcastMessage("EndWave");
        roundNumber++;
    }

    IEnumerator SpawnEnemy(int spawnerNumber)
    {
        enemySpawners[spawnerNumber].GetComponent<EnemySpawn>().SpawnEnemy();
        yield return new WaitForSeconds(0);
    }
}
