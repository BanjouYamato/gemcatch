using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI govScoreText;
    float remainTime;
    gamePlay gp;
    // Start is called before the first frame update
    void Start()
    {
        remainTime = 30;
        gp = FindObjectOfType<gamePlay>();
        StartCoroutine(coolDownTime());
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
        setGOVscoreText();
    }
    void setScoreText()
    {
        scoreText.text = "Score: " + gp.myScore + " | Time: " + remainTime;
    }
    IEnumerator coolDownTime()
    {
        while (remainTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainTime--;
        }
    }
    void setGOVscoreText()
    {
        govScoreText.text = "Score: " + gp.myScore;
    }
    public float RemainTime
    {
        get { return remainTime; }
        set { remainTime = value; }
    }
}
