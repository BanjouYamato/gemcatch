using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpeedItem : ItemSpawn
{
    
    public override void SpawnItem()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
           int random= RandomIndex();
            if(random == 0)
            { 
                SpawnTime = GetSpawnTime();
                GameObject clone = Instantiate(gameObject, new Vector2(-9.85f,Random.Range(-0.45f,1.25f)), Quaternion.identity);
                directionFly = true;
                clone.GetComponent<ItemSpawn>().directionFly = directionFly;
                Timer = SpawnTime;
            }
            else if(random == 1) 
            {
                
                SpawnTime = GetSpawnTime();                
                GameObject clone = Instantiate(gameObject, new Vector2(9.85f, Random.Range(-0.45f, 1.25f)), Quaternion.identity);
                directionFly = false;
                clone.GetComponent<ItemSpawn>().directionFly = directionFly;
                Timer = SpawnTime;
            }

        }
    }
    protected override void Effect()
    {
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundEffectManager.Instance.PlaySpeedSound();
            Effect();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("deathZone"))
        {
            Destroy(gameObject);
        }
    }
    protected override void fallingAction()
    {
        if(directionFly)
        {
            rb.velocity = Vector2.right * fallingSpeed;
        }
        else if(!directionFly) 
        {
            rb.velocity = Vector2.left * fallingSpeed;

        }
    }

    public override float GetSpawnTime()
    {
        float random = Random.Range(8f, 13f);
        return random;
    }

    public override float GetTimer()
    {
        float time = GetSpawnTime();
        return time;
    }

    
    int RandomIndex()
    {
        int random = Random.Range(0, 2);
        return random;
    }

 
}
