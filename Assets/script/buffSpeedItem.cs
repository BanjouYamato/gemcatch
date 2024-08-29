using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffSpeedItem : MonoBehaviour
{
    public GameObject buffItem;
    public float spongeTime;
    float TimeSponge;
    public int buffStat;
    gamePlay gp;



    // Start is called before the first frame update
    void Start()
    {
        TimeSponge = spongeTime;
        gp = FindObjectOfType<gamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gp.GameOver)
        {
            return;
            
        }
        TimeSponge -= Time.deltaTime;
        if(TimeSponge <=0)
        {
            spongeItem();
            TimeSponge = spongeTime;
            
        }
    }
    void spongeItem()
    {
        float rDomPosY = Random.Range(-1.5f, 0.3f);
        if (buffItem)
        {
            Instantiate(buffItem, new Vector2(-9.75f, rDomPosY), Quaternion.identity);
        }
       
    }
    
}
