using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class NextLevelMenuController : MonoBehaviour
{
    public GameObject playBtn, ExitBtn, retryBtn, pauseBtn;
    public GameObject Panel, moveCanvas;

    private void Start()
    {
        Panel.SetActive(false);
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

    public void NextLevel()
    {
        SoundController.instance.SoundEffect(9);

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
    


}
