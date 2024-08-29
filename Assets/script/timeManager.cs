using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    UI uiSystem;
    public GameObject plus2;
    public GameObject down2;
    int plus2Stat= 2;
    int down2Stat= -2;
    AudioSource aS;
    public AudioClip plusSound;
    public AudioClip downSound;
     float spongePTime;
     float spongeDTime;
    gamePlay gp;

    // Start is called before the first frame update
    void Start()
    {
        uiSystem = FindObjectOfType<UI>();
        aS = GetComponent<AudioSource>();
        gp = FindObjectOfType<gamePlay>();
        spongeDTime = Random.Range(5, 12);
        spongePTime = Random.Range(5, 12);  
    }

    // Update is called once per frame
    void Update()
    {
        if (gp.GameOver)
        {
            return;
        }
        spongePTime -= Time.deltaTime;
        spongeDTime -= Time.deltaTime;
        if (spongePTime <=0)
        {
            spongePlusTime();
            spongePTime = Random.Range(5, 12);
          
        }
        if (spongeDTime <= 0)
        {
            spongeDownTime();
            spongeDTime = Random.Range(5, 12);
           
        }

    }
    public void plusTime()
    {
        aS.PlayOneShot(plusSound);
        uiSystem.RemainTime += plus2Stat;
    }
    public void downTime()
    {
        aS.PlayOneShot(downSound);
        uiSystem.RemainTime += down2Stat;
    }
    void spongePlusTime()
    {
        float rDOmX = Random.Range(-8.35f, 8.38f);
        if (plus2)
        {
            Instantiate(plus2, new Vector2(rDOmX, 6.16f), Quaternion.identity);
        }
    }
    void spongeDownTime()
    {
        float rDOmX = Random.Range(-8.35f, 8.38f);
        if (down2)
        {
            Instantiate(down2, new Vector2(rDOmX, 6.16f), Quaternion.identity);
        }
    }
}
