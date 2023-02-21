using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;


public class MainMenuController : MonoBehaviour
{
    public string sceneName;

    public GameObject fadeScreen;

    public Text gameNameTxt;
    public GameObject startBtn, settingsBtn;
    public GameObject settingsPanel, butonlarPanel, levelsPanel;

    private void Start()
    {
        SoundController.instance.SoundEffect(8);

        StartCoroutine(OpenNextRoutine());
    }


    public void StartGame()
    {
        SoundController.instance.SoundEffect(9);

        StartCoroutine(OpenGameRoutine());
    }

    public void Settings()
    {
        SoundController.instance.SoundEffect(9);
        settingsPanel.SetActive(true);
    }

   

    public void Exit()
    {
        StartCoroutine(OpenNextRoutine());
        settingsPanel.SetActive(false);
    }


    IEnumerator OpenNextRoutine()
    {
        yield return new WaitForSeconds(.1f);
        gameNameTxt.GetComponent<CanvasGroup>().DOFade(1, .5f);

        yield return new WaitForSeconds(.2f);
        startBtn.GetComponent<CanvasGroup>().DOFade(1, .5f);
        startBtn.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);


        yield return new WaitForSeconds(.2f);
        settingsBtn.GetComponent<CanvasGroup>().DOFade(1, .5f);
        settingsBtn.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }

    IEnumerator OpenGameRoutine()
    {
        yield return new WaitForSeconds(.3f);

        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(.1f);

        levelsPanel.SetActive(true);


    }
}
