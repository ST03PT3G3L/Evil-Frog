using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCountText;
    public GameObject player;
    public GameObject[] enemySpawners;

    public int roundNumber = 0;
    public int space = 1;
    private int totalWaves;

    [System.Serializable]
    public class Round
    {
        public List<GameObject> enemies;
        public float spawnDelay;
    }

    public List<Round> rounds = new List<Round>();

    private void Start()
    {
        totalWaves = rounds.Count;
        waveCountText.text = "Wave: " + roundNumber + "/" + totalWaves;
    }

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

    public void StartRound()
    {
        int wave = roundNumber + 1;
        waveCountText.text = "Wave: " + wave + "/" + totalWaves;
        StartCoroutine(InitiateNextRound());
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
