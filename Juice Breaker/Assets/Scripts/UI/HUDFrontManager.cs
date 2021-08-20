using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDFrontManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTxt;

    public void PrintScore(Vector2 pos)
    {
        Instantiate(scoreTxt, pos, transform.rotation, transform);
    }
}
