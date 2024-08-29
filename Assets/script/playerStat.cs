using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStat : MonoBehaviour
{

    moveCharacter mc;
    buffSpeedItem buffSpeedItem;
    public AudioSource aS;
    public AudioClip receiveSound;
    Color speedColor = Color.red;
    Color defaultColor = Color.white;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponent<moveCharacter>();
        buffSpeedItem = FindObjectOfType<buffSpeedItem>();
         sr = GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator buffEff()
    {
        aS.PlayOneShot(receiveSound);
        mc.moveSpeed += buffSpeedItem.buffStat;
        sr.color = speedColor;
        yield return new WaitForSeconds(5);
        mc.moveSpeed -= buffSpeedItem.buffStat;
        sr.color = defaultColor;
       
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("speedBuff")){
            StartCoroutine(buffEff());
            Destroy(col.gameObject);
        }
    }
}
