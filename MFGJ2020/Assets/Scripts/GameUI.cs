using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject endScreen;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;

    public GameObject pauseScreen;
    public PathManager path;

    //instance
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText ()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void SetEndScreen (bool hasWon)
    {
        endScreen.SetActive(true);
        endScreenHeader.text = "<b>Score</b>\n" + GameManager.instance.score;
        if(hasWon)
        {
            endScreenHeader.text = "You Win";
            endScreenHeader.color = Color.green;
        }    
        else
        {
            endScreenHeader.text = "GameOver";
            endScreenHeader.color = Color.red;

        }
    }

    public void OnRestartButton ()
    {
        path.ResetWaypoints();
        if (GameManager.instance.paused)
            GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuButton ()
    {
        if (GameManager.instance.paused)
            GameManager.instance.TogglePauseGame();

        SceneManager.LoadScene(0);
    }

    public void TogglePauseScreen(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }    

}



