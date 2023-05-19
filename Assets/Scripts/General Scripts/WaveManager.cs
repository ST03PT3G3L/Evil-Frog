using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject merchantObject;
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] private GameObject help;
    public GameObject player;
    public GameObject[] enemySpawners;
    private MapExpanding expander;
    private bool chosenReward = false;

    public int roundNumber = 0;
    public int space = 1;
    private int totalWaves;

    private bool waveStarted = false;

    [SerializeField] private AudioMixerSnapshot outOfBattle;
    [SerializeField] private AudioMixerSnapshot inToBattle;

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
        waveCountText.text = roundNumber + "/" + totalWaves;
        expander = GetComponent<MapExpanding>();
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
        if (chosenReward)
        {
            waveStarted = true;
            int wave = roundNumber + 1;
            waveCountText.text = wave + "/" + totalWaves;
            StartCoroutine(InitiateNextRound());

            if (GameObject.FindGameObjectWithTag("Merchant") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Merchant"));
            }

            inToBattle.TransitionTo(1f);

            expander.info.SetActive(false);
        }
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
        outOfBattle.TransitionTo(1f);
        ModeManager.editMode = true;
        waveStarted = false;
        BroadcastMessage("EndWave");
        GameObject.Find("Soul Forge").GetComponentInChildren<SoulForge>().setupShop(false);
        roundNumber++;

        if (expander != null)
        { expander.Expand(roundNumber); }

        if (merchantObject != null && roundNumber % 2 == 0 && roundNumber != 0)
        {
            Instantiate(merchantObject, merchantObject.GetComponent<MerchantArrival>().startPos, Quaternion.identity);
        }

        chosenReward = false;
        help.SetActive(false);
    }

    public void RewardChosen()
    {
        chosenReward = true;
    }
}
