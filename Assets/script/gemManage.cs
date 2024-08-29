using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemManage : MonoBehaviour
{
    public float fallingSpeed;
    gamePlay gp;
    AudioSource aS;
    public AudioClip groundFallingSound;
     
    

    // Start is called before the first frame update
    void Start()
    {
        gp = FindObjectOfType<gamePlay>();
        aS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gp.GameOver)
        {
            return;
        }
        transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))

        {
            
            aS.PlayOneShot(groundFallingSound);
            Destroy(gameObject, 0.1f);
        }
        if (col.gameObject.CompareTag("Player") && !gp.GameOver)
        {
            
            gp.increaseScore();
            Destroy(gameObject);

        }
        if (col.gameObject.CompareTag("vatCan"))

        {

            aS.PlayOneShot(groundFallingSound);
            Destroy(gameObject, 0.1f);
        }
    }
}
