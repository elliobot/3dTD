using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaster : MonoBehaviour
{

    public float gameSpeed = 1f; 

    public static WaveMaster instance;

    public Transform enemyPrefab;
    public Transform enemyPrefabFast;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public int waveNumber = 1;

    public float enemySpawnWait = 0.7f;

    private int waveIndex = 0;

    public int normalEmemies;
    public int fastEnemies;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Upgrades");
            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnWait = enemySpawnWait - (waveNumber/100);
        Time.timeScale = gameSpeed;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        int totalEnemiesToSpawn = fastEnemies + normalEmemies;
        
        int i = 0;

        for (int j = 0; j < totalEnemiesToSpawn; j++)
        {
            if (i < normalEmemies)
            {
                SpawnEnemy();
                i++;
                yield return new WaitForSeconds(enemySpawnWait);
                countdown = timeBetweenWaves;


            }

        }
        countdown = timeBetweenWaves;
        UpgradeWave();
        waveNumber++;
    }

    void UpgradeWave()
    {
        normalEmemies += 1;
        fastEnemies += 1;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, enemyPrefab.rotation);
    }
    void SpawnFast()
    {
        Instantiate(enemyPrefabFast, spawnPoint.position, enemyPrefabFast.rotation);
    }
}
