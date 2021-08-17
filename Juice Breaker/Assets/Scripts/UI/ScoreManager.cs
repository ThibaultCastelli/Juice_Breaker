using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;

    [SerializeField] EventFloat saveScoreEvent;

    float currentScore;
    float highScore;
    float scoreMultiplier = 1f;

    private void Start()
    {
        highScore = SaveManager.CurrentSave.highScore;
        UpdateScoreTxt();
    }

    public void UpScore()
    {
        currentScore += Mathf.Round(500 * scoreMultiplier);
        scoreMultiplier += 0.1f;

        UpdateScoreTxt();
    }

    public void DownScore()
    {
        currentScore -= 2000;
        if (currentScore < 0)
            currentScore = 0;

        scoreMultiplier = 1f;

        UpdateScoreTxt();
    }

    public void Save()
    {
        if (currentScore > highScore)
            saveScoreEvent.RaiseEvent(currentScore);
    }

    void UpdateScoreTxt()
    {
        scoreTxt.text = "SCORE - " + currentScore;

        if (currentScore > highScore)
            highScoreTxt.text = "HIGHSCORE - " + currentScore;
        else
            highScoreTxt.text = "HIGHSCORE - " + highScore;
    }
}
