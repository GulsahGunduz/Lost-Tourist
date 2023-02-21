using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image heart1, heart2, heart3;

    [SerializeField]
    Sprite fullHeart, emptyHeart;

    [SerializeField]
    public TMP_Text coinText;

    

    LevelManager levelManager;
    PlayerHealthController PHC;

    private void Awake()
    {
        PHC = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }

    public void TotalCoinUpdate()
    {
        coinText.text = levelManager.pickUpGem.ToString();
    }

   

    public void HealthUpdate()
    {
        switch (PHC.currentHealth)
        {
            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;

            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;

            case 1:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
        }
    }
}
