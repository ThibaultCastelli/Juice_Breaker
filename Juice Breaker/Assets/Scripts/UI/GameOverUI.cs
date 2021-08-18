using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    #region Variables
    [Header("TEXTS")]
    [SerializeField] TextMeshProUGUI gameOverTxt;
    [SerializeField] TextMeshProUGUI winTxt;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [Space]

    [Header("COMPONENTS")]
    [SerializeField] SaveManager save;
    [Space]

    [Header("EVENTS")]
    [SerializeField] Event previousSceneEvent;
    #endregion

    private void Start()
    {
        if (save.CurrentSave.highScore == save.CurrentSave.lastScore)
            winTxt.gameObject.SetActive(true);
        else
            gameOverTxt.gameObject.SetActive(true);

        scoreTxt.text = "SCORE -     " + save.CurrentSave.lastScore;
        highScoreTxt.text = "HIGHSCORE -     " + save.CurrentSave.highScore;
    }

    #region Functions
    public void TryAgain()
    {
        previousSceneEvent.RaiseEvent();
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
    #endregion
}
