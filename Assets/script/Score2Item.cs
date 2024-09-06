using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score2Item : FallingItem
{
    public override float GetSpawnTime()
    {
        float random = Random.Range(1f, 5f);
        return random;
    }
    public override float GetTimer()
    {
        float time = GetSpawnTime();
        return 1;
    }

    protected override void Effect()
    {
        ScoreManager.Instance.Score += 2;
    }
}
