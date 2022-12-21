using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject light;

    private void Start()
    {
        gameIsOver = false;
        Time.timeScale = 1f;
        light.GetComponent<Light>().intensity = 2;
    }

    void Update()
    {
        if (gameIsOver) return;

        if(PlayerStats.Lives<=0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);

    }
}
