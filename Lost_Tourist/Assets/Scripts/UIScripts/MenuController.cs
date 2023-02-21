using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public GameObject retryBtn, exitBtn, pauseBtn;
    public GameObject panel, moveCanvas;

    public static bool GameIsPaused;
    public GameObject pausePanel;

    private void Start()
    {
        panel.SetActive(false);
        moveCanvas.SetActive(false);
        pauseBtn.SetActive(false);
    }

    public void Retry()
    {
        SoundController.instance.SoundEffect(9);

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SoundController.instance.SoundEffect(9);

        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        panel.SetActive(true);
        moveCanvas.SetActive(true);
        pauseBtn.SetActive(true);
    }

    public void Pause()
    {

        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

}
