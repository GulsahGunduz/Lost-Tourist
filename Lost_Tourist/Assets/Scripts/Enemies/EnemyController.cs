using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform leftTarget, rightTarget;
    bool Right;

    public float moveTime, waitTime;
    float mCount, wCount;

    Rigidbody2D rb;
    Animator anim;

    public SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
        Right = true;

        mCount = moveTime;
    }

    private void Update()
    {
        if(mCount > 0)
        {
            mCount -= Time.deltaTime;

            if (Right)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                sr.flipX = true;

                if (transform.position.x > rightTarget.position.x)
                {
                    Right = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                sr.flipX = false;

                if (transform.position.x < leftTarget.position.x)
                {
                    Right = true;
                }

            }
            if(mCount <= 0)
            {
                wCount = waitTime;
            }

            anim.SetBool("move", true);
        }
        else if(wCount > 0)
        {
                wCount -= Time.deltaTime;
                rb.velocity = new Vector2(0, rb.velocity.y);

                if (wCount <= 0)
                {
                    mCount = moveTime;
                }

                anim.SetBool("move", false);
        }
        

        
    }

    
    

}
