using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private List<Transform> enemySpawnPoints = new List<Transform>();

    // Start is called before the first frame update

    public GameObject enemyPrefab;
    public float spawnRate = 5f;
    public float spawnRateMax = 0.3f;

    void Start()
    {
        enemySpawnPoints.Clear();

        foreach( GameObject enemySpawnPoint in GameObject.FindGameObjectsWithTag("EnemyRespawn"))
        {
            enemySpawnPoints.Add(enemySpawnPoint.transform);
        }

        InvokeRepeating("IncreaseSpawnRate", 0.1f, 5f);
        StartCoroutine(SpawnEnemy());
    }

    private void IncreaseSpawnRate()
    {
        spawnRate -= 0.1f;
        if(spawnRate <= spawnRateMax) { spawnRate = spawnRateMax; }
    }

    private IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)]);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
