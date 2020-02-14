using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("PauseMenu Screen")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    public static UImanager uiManager;
    void Awake()
    {
        uiManager = this;
    }

    public void UpdateHealthBar(int currentHP, int maxHP)
    {
        healthBarFill.fillAmount = (float)currentHP / maxHP;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo : " + currentAmmo + "/ " + maxAmmo;
    }

    public void TogglePauseMenu(bool Pause)
    {
        pauseMenu.SetActive(Pause);
    }

    public void SetGameScreen(bool isWon,int score)
    {
        endGameScreen.SetActive(true);

        if (isWon)
        {
            endGameHeaderText.text = "You Win";
            endGameHeaderText.color = Color.green;
        }
        else
        {
            endGameHeaderText.text = "You Lose";
            endGameHeaderText.color = Color.red;
        }

        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    public void OnResumeButton()
    {
        GameManager.gameManager.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
        GameManager.gameManager.TogglePauseGame();
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
