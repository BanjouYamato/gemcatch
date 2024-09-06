using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUp2Item : FallingItem
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
        TimeManager.Instance.Timer += 2;
    }
}
