using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public CanvasController canvasController;
    public EnemySpawner enemySpawner;
    public GameObject player;

    private bool isPlaying;

    void Start() {
        player.SetActive(false);
    }

    public void StartGame() {
        canvasController.StartGame();
        enemySpawner.Spawn();
        player.SetActive(true);

        if (!isPlaying)
            isPlaying = true;
    }

    public void GameEnded() {
        if (!isPlaying)
            return;

        canvasController.EndGame();
        player.GetComponent<PlayerPanzer>().enabled = false;

        isPlaying = false;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
