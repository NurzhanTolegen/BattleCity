using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject restartPanel;

    // Start is called before the first frame update
    void Start() {
        menuPanel.SetActive(true);
        restartPanel.SetActive(false);
    }

    public void StartGame() {
        menuPanel.SetActive(false);
    }
    public void EndGame() {
        restartPanel.SetActive(true);
    }

}
