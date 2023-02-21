using UnityEngine;

public class EffectManager : MonoBehaviour
{
    float liveTime;

    private void Start()
    {
        Destroy(gameObject, liveTime);
    }
}
