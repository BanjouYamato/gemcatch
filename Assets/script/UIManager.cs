using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
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
}
