using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    #region Variables
    [Header("EVENTS")]
    [SerializeField] Event goToNextSceneEvent;

    string _savePath;
    public Save CurrentSave { get; private set; }
    #endregion

    private void Awake()
    {
        _savePath = Application.persistentDataPath + "/juice.json";
        CurrentSave = GetSave();
    }

    #region Functions
    Save GetSave()
    {
        if (!File.Exists(_savePath))
            return new Save();

        string json = File.ReadAllText(_savePath);
        return JsonUtility.FromJson<Save>(json);
    }

    IEnumerator SaveCoroutine(float newHighScore)
    {
        CurrentSave.highScore = newHighScore;
        string json = JsonUtility.ToJson(CurrentSave);
        File.WriteAllText(_savePath, json);

        yield return new WaitUntil(() => File.Exists(_savePath));
        goToNextSceneEvent.RaiseEvent();
    }

    // Event listener of SaveScore
    public void Save(float newHighScore) => StartCoroutine(SaveCoroutine(newHighScore));
    #endregion
}
