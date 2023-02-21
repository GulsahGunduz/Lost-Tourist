using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioSource[] soundEffects;


    private void Awake()
    {
        instance = this;
    }


    public void SoundEffect(int index)
    {
        soundEffects[index].Stop();
        soundEffects[index].Play();
    }

    public void MixSound(int index)
    {
        soundEffects[index].Stop();
        soundEffects[index].pitch = Random.Range(0.08f, 1.3f);
        soundEffects[index].Play();
    }

  
}
