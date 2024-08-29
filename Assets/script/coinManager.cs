using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ground"))

        {

            aS.PlayOneShot(groundFallingSound);
            Destroy(gameObject, 0.1f);
        }
        if (col.CompareTag("Player") && !gp.GameOver)
        {

            gp.coinReceive();
            Destroy(gameObject);

        }
        if (col.CompareTag("vatCan"))

        {

            aS.PlayOneShot(groundFallingSound);
            Destroy(gameObject, 0.1f);
        }
    }
  
}
