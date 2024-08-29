using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffEffect : MonoBehaviour
{
    public float flySpeed;

    buffSpeedItem bSItem;

   
    
    // Start is called before the first frame update
    void Start()
    {

        bSItem = FindObjectOfType<buffSpeedItem>();

       
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeedItem();
        
        
    }
 
    void moveSpeedItem()
    {
        
        
            transform.Translate(Vector2.right * flySpeed * Time.deltaTime);
         
        
       
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("deathZone"))
        {
            Destroy(gameObject);
            
        }
    }

}
