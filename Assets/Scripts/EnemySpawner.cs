using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour {

    public Transform playerBase;

    public Transform[] enemySpawnPoints;
    public EnemyPanzer enemyPrefab;

    public int maxEnemyCount = 10;
    public float minSpawnPeriod = 3;
    public float maxSpawnPeriod = 10;

    public UnityEvent onWin;

    private int diedEnemyCount;

    public void Spawn() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        for (int i = 0; i < maxEnemyCount; i++) {
            float period = Random.Range(minSpawnPeriod, maxSpawnPeriod);
            yield return new WaitForSeconds(period);

            //a separate coroutine so that the spawn timer does not stop
            StartCoroutine(SpawnEnemyWithEffect());
        }
    }

    IEnumerator SpawnEnemyWithEffect() {
        int spawnPointId = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[spawnPointId];

        EffectsController.PlaySpawnEffect(spawnPoint.position);
        yield return new WaitForSeconds(1f);

        EnemyPanzer panzer = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //set player base as a target
        panzer.target = playerBase;

        //if dies then invoke
        Health panzerHealth = panzer.GetComponent<Health>();
        panzerHealth.onDeath.AddListener(EnemyDied);
    }

    public void EnemyDied() {
        diedEnemyCount++;

        if (diedEnemyCount >= maxEnemyCount)
            onWin.Invoke();
    }
}
