using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score1Item : FallingItem
{
    public override float GetSpawnTime()
    {
        return 1.5f;
    }

    protected override void Effect()
    {
        ScoreManager.Instance.Score++;
    }
}
