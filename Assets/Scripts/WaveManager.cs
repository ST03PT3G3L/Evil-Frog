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

    private bool waveStarted = false;

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
            //StartCoroutine(InitiateNextRound());
        }

        if (waveStarted)
        {
            ModeManager.editMode = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(enemies.Length);
            if (enemies.Length == 0)
            {
                WaveEnd();
            }
        }
    }

    private void GetSpawners()
    {
        enemySpawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    public void StartRound()
    {
        waveStarted = true;
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
            StartCoroutine(SpawnEnemy(i, enemy));
            yield return new WaitForSeconds(round.spawnDelay);

            if(i < spawnersAmount - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    IEnumerator SpawnEnemy(int spawnerNumber, GameObject enemy)
    {
        enemySpawners[spawnerNumber].GetComponent<EnemySpawn>().SpawnEnemy(enemy);
        yield return new WaitForSeconds(0);
    }

    private void WaveEnd()
    {
        ModeManager.editMode = true;
        waveStarted = false;
        BroadcastMessage("EndWave");
        roundNumber++;
    }
}
