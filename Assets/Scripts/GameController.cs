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
    
    // Start is called before the first frame update
    void Start() {
        player.SetActive(false);
    }

    public void StartGame() {
        canvasController.StartGame();
        player.SetActive(true);
        enemySpawner.Spawn();
    }

    public void GameEnded() {
        canvasController.EndGame();
        player.GetComponent<PlayerPanzer>().enabled = false;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
