using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    TMP_Text timeText;

    public float time;

    PlayerHealthController PHC;
    [SerializeField]
    GameObject GameOverPanel;


    private void Awake()
    {
        PHC = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void Start()
    {
        timeText.text = time.ToString();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timeText.text = ((int)time).ToString();

        if(time < 0)
        {
            PHC.Die();
            GameOverPanel.SetActive(true);
        }
    }


    
}
