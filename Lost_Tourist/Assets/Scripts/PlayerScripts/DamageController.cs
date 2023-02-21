using UnityEngine;
using System.Collections.Generic;

public class DamageController : MonoBehaviour
{
    PlayerHealthController PHC;

    

    private void Awake()
    {
        PHC = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PHC.TakeDamage();
        }

        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PHC.TakeDamage();

        }
        
    }

}
