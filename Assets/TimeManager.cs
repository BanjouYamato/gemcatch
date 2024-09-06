using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
   public static TimeManager Instance {  get; private set; }

    int time = 30;

    private void Start()
    {
        StartCoroutine(CoolDownTime());

    }
    private void Update()
    {

    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Timer
    {
        get { return time; }
        set { time = value; }
    }

    IEnumerator CoolDownTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;

        }
    }
}
