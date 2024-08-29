using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemManager : MonoBehaviour
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
        transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            
        {
            aS.PlayOneShot(groundFallingSound);
            Destroy(gameObject,0.1f);
        }
        if (col.gameObject.CompareTag("Player") )
        {
            
            gp.increaseScore();
            Destroy(gameObject);
            
        }
    }
}
