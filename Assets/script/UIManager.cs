using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTimeText;

    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreOverText;

    private void Update()
    {
        SetScoreTimeText();
        SetGameOverPanel();
        SetScoreOverText();
    }
    void SetScoreTimeText()
    {
        scoreTimeText.text = "Score: " + ScoreManager.Instance.Score
            + " | Time: " + TimeManager.Instance.Timer;
    }

    void SetGameOverPanel()
    {
        if (ScoreManager.Instance.GameOver)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    void SetScoreOverText()
    {
        scoreOverText.text = "Score: " + ScoreManager.Instance.Score;
    }

    public void ReplayAction()
    {
        SceneManager.LoadScene("gemCatcher");
        ScoreManager.Instance.GameOver = false;
        ScoreManager.Instance.Score = 0;
        TimeManager.Instance.Timer = 30;
    }
}
