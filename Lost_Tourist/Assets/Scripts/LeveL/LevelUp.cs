using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelUp : MonoBehaviour
{
    

    Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){

            anim.SetTrigger("lever");

            //other.gameObject.GetComponent<Animator>().SetTrigger("Win");

            SoundController.instance.soundEffects[8].Stop();
            SoundController.instance.SoundEffect(5);

            StartCoroutine(WaitWin());
        }
    }

    IEnumerator WaitWin()
    {
        yield return new WaitForSeconds(2f);

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
