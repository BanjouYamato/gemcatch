using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallingItem : ItemSpawn
{
    public override float GetTimer()
    {
        return 0;
    }
}
