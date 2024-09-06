using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance { get; private set; }

    int score = 0;

    bool gameOver;
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

    private void Start()
    {
        GameOver = false;
    }
    private void Update()
    {
        SetGameOver();
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    void SetGameOver()
    {
        if (TimeManager.Instance.Timer <= 0)
        {
            gameOver = true;
        }
    }
    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }
}
