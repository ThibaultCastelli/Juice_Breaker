using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    #region Variables
    [Header("TEXTS")]
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] TextMeshProUGUI multiplierTxt;
    [SerializeField] TextMeshProUGUI timerTxt;
    #endregion

    #region Functions
    public void UpdateTxt(float score, float highScore, float multiplier)
    {
        scoreTxt.text = "SCORE - " + score;

        if (score > highScore)
            highScoreTxt.text = "HIGHSCORE - " + score;
        else
            highScoreTxt.text = "HIGHSCORE - " + highScore;

        multiplierTxt.text = multiplier.ToString("#.#");
    }

    public void UpdateTimer(float timer)
    {
        timerTxt.text = timer.ToString("#");
    }
    #endregion
}
