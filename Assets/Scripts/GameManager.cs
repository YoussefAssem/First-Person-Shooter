using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int currentScore;

    public bool gamePaused;

    public static GameManager gameManager;

    private void Start()
    {
        gameManager = this;

        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;

        BulletPool.PoolInit();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
        Cursor.lockState = gamePaused == true ? CursorLockMode.None:CursorLockMode.Locked;
        UImanager.uiManager.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        currentScore += score;

        UImanager.uiManager.UpdateScore(currentScore);

        if (currentScore >= scoreToWin)
            WinGame();
    }

    private void WinGame()
    {
        TogglePauseGame();
        UImanager.uiManager.SetGameScreen(true,currentScore);       
    }

    public void LoseGame()
    {
        TogglePauseGame();
        UImanager.uiManager.SetGameScreen(false, currentScore);
    }
}
