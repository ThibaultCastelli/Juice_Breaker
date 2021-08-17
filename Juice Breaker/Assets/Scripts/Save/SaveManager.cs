using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static Save CurrentSave { get; private set; }
    string _savePath;

    private void Awake()
    {
        _savePath = Application.persistentDataPath + "/juice.json";
        CurrentSave = GetSave();
    }

    public void Save(float newHighScore)
    {
        CurrentSave.highScore = newHighScore;
        string json = JsonUtility.ToJson(CurrentSave);
        File.WriteAllText(_savePath, json);
    }

    Save GetSave()
    {
        if (!File.Exists(_savePath))
            return new Save();

        string json = File.ReadAllText(_savePath);
        return JsonUtility.FromJson<Save>(json);
    }
}
