using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;

    bool isOn = true;

    AudioSource audioSource;
    public GameObject soundManager;

    private void Start()
    {
        soundOnImage = button.image.sprite;
    }

    public void ButtonClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            SoundController.instance.soundEffects[8].Stop();
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            SoundController.instance.soundEffects[8].Play();
        }

    }

    public void ButtonPlayerSoundClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            soundManager.SetActive(false);
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            soundManager.SetActive(true);
            SoundController.instance.soundEffects[8].Play();
        }
    }

}
