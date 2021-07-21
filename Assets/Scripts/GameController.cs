using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public Transform enemyPrefab;

    public int maxEnemyCount = 10;

    public float minSpawnPeriod = 3;
    public float maxSpawnPeriod = 10;

    // Start is called before the first frame update
    void Start() {
        StartGame();
    }

    void StartGame() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        for (int i = 0; i < maxEnemyCount; i++) {
            float period = Random.Range(minSpawnPeriod, maxSpawnPeriod);
            yield return new WaitForSeconds(period);

            int spawnPointId = Random.Range(0, enemySpawnPoints.Length);
            Transform spawnPoint = enemySpawnPoints[spawnPointId];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
