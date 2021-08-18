using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("STATS")]
    [SerializeField] [Range(10f, 60f)] float timer = 30f;
    [Space]

    [Header("COMPONENT")]
    [SerializeField] HUDManager hud;
    [SerializeField] SaveManager save;
    [Space]

    [Header("EVENTS")]
    [SerializeField] Event gameOverEvent;
    [SerializeField] Event goToNextSceneEvent;

    float currentScore;
    float highScore;
    float scoreMultiplier = 1f;
    #endregion

    #region Starts & Updates
    private void Start()
    {
        highScore = save.CurrentSave.highScore;
        hud.UpdateTxt(currentScore, highScore, scoreMultiplier);
    }

    private void Update()
    {
        // Reduce the timer and end the game if timer = 0
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            hud.UpdateTimer(timer);
        }
        else
            gameOverEvent.RaiseEvent();
    }
    #endregion

    #region Functions
    // Event listener of BrickBreak
    public void UpScore()
    {
        currentScore += Mathf.Round(500 * scoreMultiplier);
        scoreMultiplier *= 1.1f;

        hud.UpdateTxt(currentScore, highScore, scoreMultiplier);
    }

    // Event listener of DeathBall
    public void DownScore()
    {
        currentScore -= 2000;
        if (currentScore < 0)
            currentScore = 0;

        scoreMultiplier = 1f;

        hud.UpdateTxt(currentScore, highScore, scoreMultiplier);
    }

    // Event listener of GameOver
    public void Save()
    {
        if (currentScore > highScore)
            highScore = currentScore;

        save.Save(highScore, currentScore);
    }
    #endregion
}
