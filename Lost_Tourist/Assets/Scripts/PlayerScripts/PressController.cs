using UnityEngine;
using System.Collections.Generic;


public class PressController : MonoBehaviour
{
    [SerializeField]
    GameObject dieEffect;

    PlayerController playerController;

    public float heartChance;
    public GameObject heart;
    
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            float range = Random.Range(0f, 100f);

            if(range < heartChance)
            {
                Instantiate(heart, other.transform.position, other.transform.rotation);
            }

            Instantiate(dieEffect, transform.position, transform.rotation);

            other.transform.parent.gameObject.SetActive(false);


            playerController.JumpForEnemy();

            SoundController.instance.SoundEffect(3);
        }
    }
}
