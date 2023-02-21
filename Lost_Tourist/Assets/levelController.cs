using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelController : MonoBehaviour
{
    
  

    public Button[] levels;
    int passed;

    private void Start()
    {
        passed = PlayerPrefs.GetInt("levelPassed");
        levels[0].interactable = false;
        levels[1].interactable = false;
        levels[2].interactable = false;
        levels[3].interactable = false;
        levels[4].interactable = false;
        levels[5].interactable = false;
        levels[6].interactable = false;
        levels[7].interactable = false;
        levels[8].interactable = false;

        switch (passed)
        {
            case 1:
                levels[0].interactable = true;
                break;
            case 2:
                levels[0].interactable = true;
                levels[1].interactable = true;

                break;
            case 3:
                levels[0].interactable = true;
                levels[1].interactable = true;
                levels[2].interactable = true;
                break;
            case 4:
                levels[0].interactable = true;
                levels[1].interactable = true;
                levels[2].interactable = true;
                levels[3].interactable = true;
                break;
            case 5:
                levels[0].interactable = true;
                levels[1].interactable = true;
                levels[2].interactable = true;
                levels[3].interactable = true;
                levels[4].interactable = true;
                break;
            case 6:
                levels[0].interactable = true;
                levels[1].interactable = true;
                levels[2].interactable = true;
                levels[3].interactable = true;
                levels[4].interactable = true;
                levels[5].interactable = true;
                levels[6].interactable = true;
                levels[7].interactable = true;
                break;
            case 7:
                levels[0].interactable = true;
                levels[1].interactable = true;
                levels[2].interactable = true;
                levels[3].interactable = true;
                levels[4].interactable = true;
                levels[5].interactable = true;
                levels[6].interactable = true;
                levels[7].interactable = true;
                levels[8].interactable = true;
                break;

        }
    }

    public void LevelLoad(int level)
    {
        SoundController.instance.SoundEffect(9);
        SceneManager.LoadScene(level);

    }

    
}
