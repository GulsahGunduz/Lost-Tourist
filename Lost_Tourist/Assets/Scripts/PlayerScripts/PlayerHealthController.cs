using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    UIController uiController;
    PlayerController playerController;

    public float surviveTime;
    float surviveCount;

    [SerializeField]
    GameObject GameOverPanel;

    Animator anim;

    [SerializeField]
    GameObject DieEffect;

    SpriteRenderer sr;


    bool show;

    private void Awake()
    {
        uiController = Object.FindObjectOfType<UIController>();
        sr = GetComponent<SpriteRenderer>();
        playerController = Object.FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        surviveCount -= Time.deltaTime;

        if (surviveCount <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }

    public void HeartUpdate()
    {
        currentHealth++;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        uiController.HealthUpdate();
        SoundController.instance.SoundEffect(7);
    }

    public void TakeDamage()
    {
        if (surviveCount <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                Instantiate(DieEffect, transform.position, transform.rotation);
                Die();

               
            }
            else
            {
                surviveCount = surviveTime;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.7f);
                playerController.Reaction();

                SoundController.instance.SoundEffect(2);

            }
            uiController.HealthUpdate();
        }
    }

    public void Die()
    {
            currentHealth = 0;
            anim.SetTrigger("die");
            Time.timeScale = 0; 


        SoundController.instance.SoundEffect(0);
        Time.timeScale = 0;

        GameOverPanel.SetActive(true);
    }

   
}
    
