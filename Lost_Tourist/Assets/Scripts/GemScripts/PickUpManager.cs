using UnityEngine;
using System.Collections.Generic;

public class PickUpManager : MonoBehaviour
{
    bool pickUp;

    [SerializeField]
    bool isHeart, isCoin;

    [SerializeField]
    GameObject pickUpEffect, heartEffect;

    PlayerHealthController PHC;
    UIController uiController;
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        PHC = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !pickUp)
        {
            
            if (isCoin)
            {
                levelManager.pickUpGem++;
                pickUp = true;

                Destroy(gameObject);
                Instantiate(pickUpEffect, transform.position, Quaternion.identity);


                uiController.TotalCoinUpdate();

                SoundController.instance.SoundEffect(1);

                if(levelManager.pickUpGem == 15)
                {
                    PHC.HeartUpdate();
                    isHeart = true;
                    Instantiate(heartEffect, transform.position, Quaternion.identity);
                }
            }

            if (isHeart)
            {
                if(PHC.currentHealth != PHC.maxHealth)
                {
                    pickUp = true;
                    Destroy(gameObject,1f);

                    PHC.HeartUpdate();
                    Instantiate(pickUpEffect, transform.position, Quaternion.identity);
                    SoundController.instance.SoundEffect(1);
                }
            }
        }

    }

    

}
