using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemAction : MonoBehaviour
{
    [SerializeField] List<ItemSpawn> itemList = new();



    private void Update()   
    {
        if (ScoreManager.Instance.GameOver)
        {
            return;
        }
        SpawnItemActive();
    }

    void GetInfo()
    {
        foreach (ItemSpawn item in itemList)
        {
            Debug.Log("name: " + item.name + "/" + "spawnTime: " + item.GetSpawnTime() + "Timer: "+ item.GetTimer());
        }
    }

    void SpawnItemActive()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            ItemSpawn item = itemList[i];
            item.SpawnItem();
            
              
        }
    }

  
}
