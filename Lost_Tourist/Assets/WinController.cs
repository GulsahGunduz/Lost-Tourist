using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class WinController : MonoBehaviour
{
   

    [SerializeField]
    GameObject winEffect1, winEffect2, winEffect3;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(winEffect1, transform.position, transform.rotation);

            Instantiate(winEffect2, new Vector3(159, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(winEffect3, new Vector3(155, transform.position.y, transform.position.z), transform.rotation);

            



            SoundController.instance.soundEffects[8].Stop();
            SoundController.instance.SoundEffect(5);

            StartCoroutine(WaitWinWin());
        }

        IEnumerator WaitWinWin()
        {
            yield return new WaitForSeconds(3f);

            Time.timeScale = 0;
            SceneManager.LoadScene(0);
        }
    }
}
