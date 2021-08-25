using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GP_UIManager : MonoBehaviour
{
    public static GP_UIManager instance;
    public Text scoreText;
    public Text end_scoreText; 
    public GameObject PauseMenu;
    public GameObject gameOverUI;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        scoreTextUpdater();
        if (Player.gameIsOver)
        {
            gameOverUI.SetActive(true);
        }
        
    }

    public void scoreTextUpdater()
    {
        scoreText.text = Player.score.ToString() + " m";
        end_scoreText.text = Player.score.ToString();
    }

    public void pauseButton_ ()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    public void pauseMenu_continues ()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    public void pauseMenu_Home()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void pauseMenu_Restart ()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    
    
}
