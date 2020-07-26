using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 10;
    bool gameEnded = false;
    public int score;

    public bool paused;

    //initialization
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        paused = !paused;

        if (paused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;

        GameUI.instance.TogglePauseScreen(paused);
    }

    public void GameOver()
    {
        GameUI.instance.SetEndScreen(false);
        Time.timeScale = 0.0f;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    public void WinGame()
    {
        GameUI.instance.SetEndScreen(true);
        Time.timeScale = 0.0f;
    }
    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
        GameUI.instance.UpdateScoreText();
    }

    public void LevelEnd()
    {
        // is this the last level?
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            WinGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
}
