using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDown2Item : FallingItem
{
    public override float GetSpawnTime()
    {
        float random = Random.Range(5f, 10f);
        return random;
    }
    public override float GetTimer()
    {
        float time = GetSpawnTime();
        return time;
    }

    protected override void Effect()
    {
        TimeManager.Instance.Timer -= 2;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundEffectManager.Instance.PlayDownSound();
            Effect();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") ||
          collision.CompareTag("vatCan"))
        {
            SoundEffectManager.Instance.PlayMissSound();
            Destroy(gameObject);
        }
    }
}
