using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject pausePanel;

    public static bool fromRestart = false;

    void Awake()
    {
        if (fromRestart)
        {
            startPanel.SetActive(false);
            fromRestart = false;
        }
        else
        {
            startPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


    public void GameStart()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }
     
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        fromRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
