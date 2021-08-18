using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public Save()
    {
        highScore = 0;
        lastScore = 0;
    }

    public float highScore;
    public float lastScore;
}
