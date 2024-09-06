using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public float moveSpeed;

    float Timer;

    float dirX;

    public float jumpForce;

    float jumpCount;

    Animator animator;

    Rigidbody2D rb;

    public Transform rayTransform;

    public float distance;

    bool facingRight = true;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        jumpCount = 0;
    }

    private void FixedUpdate()
    {
        LimitMove();
        SetAnimationRuning();
        FlipActive();
    }
    private void Update()
    {
        
        JumpAction();
    }

    void SetAnimationRuning()
    {
        if (dirX != 0) animator.SetBool("isMove", true);
        else animator.SetBool("isMove", false);
    }

    void LimitMove()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX < 0 && transform.position.x <= -8.21f || dirX >= 0 && transform.position.x >= 8.35f)
        {
            rb.velocity = new Vector2(0,rb.velocity.y); 
            Debug.Log("dir: "+ dirX+ "/"+transform.position);
            Debug.Log(rb.velocity);
        }
        else
        {
            
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        if (ScoreManager.Instance.GameOver)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            float moveMent = dirX * moveSpeed;

            rb.velocity = new Vector2(moveMent, rb.velocity.y);
        }
    }

    void JumpAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <2)
        {
            SoundEffectManager.Instance.PlayJumpSound();
            animator.SetBool("isJump", true);
            rb.velocity = Vector2.up * jumpForce;
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(rayTransform.position, Vector2.down, distance, LayerMask.GetMask("vatCan"));
        if (collision.gameObject.CompareTag("Ground") || hit.collider != null)
        {
            animator.SetBool("isJump", false);
            jumpCount = 0;
        }
    }

    void FlipActive()
    {
        if(facingRight && dirX > 0)
        {
            Flip();
        }
        else if (!facingRight && dirX < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
    
}
