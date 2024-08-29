using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    Animator isMovine;
    float xDirection;
    public float moveSpeed;
    float moveMent;
    gamePlay gp;
    public float jumpStrength;
    bool isGround;
    Rigidbody2D rb;
    AudioSource aSource;
    public AudioClip jumpSound;
     Animator anim;
    int countJump;
    // Start is called before the first frame update
    void Start()
    {
        gp = FindObjectOfType<gamePlay>();
        isMovine = GetComponent<Animator>();
        isGround = true;
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        countJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gp.GameOver)
        {
            return;
        }
        
        xDirection = Input.GetAxisRaw("Horizontal");
        moveMent = xDirection * moveSpeed * Time.deltaTime;
        if (xDirection != 0)
        {
            isMovine.SetBool("isMove", true);
        }
        else
        {
            isMovine.SetBool("isMove", false);
        }
        if (transform.position.x <= -8.35 && xDirection < 0 || transform.position.x >= 8.38 && xDirection > 0)
        {
            return;
        }
        transform.position = new Vector2 (moveMent + transform.position.x, transform.position.y);
        if (Input.GetButtonDown("Jump") && countJump <2)
        {
            isGround = false;
            aSource.PlayOneShot(jumpSound);
            jumpAction();
            countJump++;
            
        }
        if (!isGround)
        {
            anim.SetBool("isJump", true);
        }
        
    }
    void jumpAction()
    {
        rb.velocity = Vector2.up * jumpStrength;
            
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D contactPoint = col.GetContact(0);
        Vector2 directContact = contactPoint.point - (Vector2)transform.position;
        if (col.gameObject.CompareTag("Ground") )
        {
            isGround = true;
            anim.SetBool("isJump", false);
            countJump = 0;
        }
        else if (col.gameObject.CompareTag("vatCan"))
        {
            if (directContact.y < 0)
            {
                isGround = true;
                anim.SetBool("isJump", false);
                countJump = 0;
            }
        }
    }
    public bool IsGround 
    { 
        get { return isGround; }
        set { isGround = value; }   
    }
   
}
