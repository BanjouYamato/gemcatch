using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePlay : MonoBehaviour
{
    public GameObject gemObject;
    public GameObject coinObject;
    public float spongeTime;
    float timeSpongeManage;
    int score;
    AudioSource aSource;
    public AudioClip gemReceive;
    bool isGameOver;
    UI uiManage;   
    float coinSPongeManage;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false; 
        aSource = GetComponent<AudioSource>();
        uiManage = FindObjectOfType<UI>();
        coinSPongeManage = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManage.RemainTime == 0)
        {
            uiManage.gameOverPanel.SetActive(true);
            isGameOver = true;
        }
        if (isGameOver)
        {
            return;
        }
        timeSpongeManage -= Time.deltaTime;
        if(timeSpongeManage <= 0)
        {
            spongeGem();
            timeSpongeManage = spongeTime;
        }
        coinSPongeManage -= Time.deltaTime;
        if (coinSPongeManage <= 0)
        {
            spongeCoin();
            coinSPongeManage = Random.Range(5, 10);
        }

    }
    void spongeGem()
    {
        float rDOmX = Random.Range(-8.35f, 8.38f);
        if (gameObject)
        {
            Instantiate(gemObject, new Vector2(rDOmX, 6.16f), Quaternion.identity);
        }
    }
    void spongeCoin()
    {
        float rDOmX = Random.Range(-8.35f, 8.38f);
        if (coinObject)
        {
            Instantiate(coinObject, new Vector2(rDOmX, 6.16f), Quaternion.identity);
        }
    }
    public void increaseScore()
    {
        score++;
        aSource.PlayOneShot(gemReceive);
    }
    public void coinReceive()
    {
        score += 2;
        aSource.PlayOneShot(gemReceive);
    }

    public void replayButton()
    {
        SceneManager.LoadScene("gemCatcher");
    }
   
    public int myScore
    {
        get { return score; }
        set { score = value; }
    }
    public bool GameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

}
