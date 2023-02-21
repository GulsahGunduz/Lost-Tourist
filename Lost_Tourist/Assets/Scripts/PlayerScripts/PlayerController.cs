using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody2D rb;

    [SerializeField]
    float jumpForce;

    bool isGrounded;
    bool jumpTwice;
    bool facingRight;

    public float jumpE_Force;

    public Transform groundPoint;
    public LayerMask groundLayer;

    PlayerHealthController PHC;

    Animator anim;

    public float reactionTime, reactionForce;
    float reactionCount;

    public GameObject pauseBtn;
    public GameObject panels, moveCanvas;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PHC = Object.FindObjectOfType<PlayerHealthController>();

    }

    private void Start()
    {
        panels.SetActive(true);
        moveCanvas.SetActive(true);
        pauseBtn.SetActive(true);
    }

    private void Update()
    {
        if(reactionCount <= 0)
        {
            PlayerMove();
            PlayerJump();
            Flip();

        }
        else
        {
            reactionCount -= Time.deltaTime;

            if (facingRight)
            {
                rb.velocity = new Vector2(-reactionForce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(reactionForce, rb.velocity.y);
            }
        }

        anim.SetFloat("Move", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    void PlayerMove()
    {
        float newSpeed = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(newSpeed, rb.velocity.y);
       
    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .5f, groundLayer); // yerdeyse true değilse false olucak

        if (isGrounded)
        {
            jumpTwice = true;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // vector2.up * jumpForce;

                SoundController.instance.SoundEffect(4);
            }
            else
            {
                if (jumpTwice)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTwice = false;

                    SoundController.instance.SoundEffect(4);
                }
            }
        }
    }

    void Flip()
    {
        Vector2 Scaler = transform.localScale;

        if(rb.velocity.x > 0)
        {
            facingRight = true;
            Scaler.x = -1.3f;
        }
        else if(rb.velocity.x < 0)
        {
            facingRight = false;
            Scaler.x = 1.3f;
        }
        transform.localScale = Scaler;
    }

    public void Reaction()
    {
        reactionCount = reactionTime;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("takeDamage");
    }

    public void JumpForEnemy()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpE_Force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FallColl"))
        {
            PHC.currentHealth = 0;
            PHC.TakeDamage();
        }

        if (other.gameObject.CompareTag("isGround"))
        {
            isGrounded = true;
        }
    }

    
 
    
}
