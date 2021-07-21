using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public Transform[] enemySpawnPoints;
    public Transform enemyPrefab;

    public int maxEnemyCount = 10;

    public float minSpawnPeriod = 3;
    public float maxSpawnPeriod = 10;

    public UnityEvent onWin;

    private int diedEnemyCount;

    // Start is called before the first frame update
    void Start() {
        player.SetActive(false);
        //StartGame();
    }

    public void StartGame() {
        player.SetActive(true);
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        for (int i = 0; i < maxEnemyCount; i++) {
            float period = Random.Range(minSpawnPeriod, maxSpawnPeriod);
            yield return new WaitForSeconds(period);

            StartCoroutine(SpawnEnemyWithEffect());
        }
    }

    IEnumerator SpawnEnemyWithEffect() {
        int spawnPointId = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[spawnPointId];

        EffectsController.PlaySpawnEffect(spawnPoint.position);
        yield return new WaitForSeconds(1.8f);

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void EnemyDied() {
        diedEnemyCount++;

        if (diedEnemyCount >= maxEnemyCount)
            onWin.Invoke();
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
