using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUI : MonoBehaviour
{
    [Header("TEXTS")]
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [Space]

    [Header("COMPONENTS")]
    [SerializeField] SaveManager save;

    [Header("EVENTS")]
    [SerializeField] Event nextSceneEvent;

    private void Start()
    {
        highScoreTxt.text = "HIGHSCORE - " + save.CurrentSave.highScore;
    }

    public void Play()
    {
        nextSceneEvent.RaiseEvent();
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif

        Application.Quit();
    }
}
