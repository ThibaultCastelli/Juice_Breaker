using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    #region Variables
    [Header("POOL STATS")]
    [SerializeField] [Range(0, 30)] int poolSize = 5;
    [SerializeField] GameObject ballPrefab;
    [Space]

    [Header("BALL STATS")]
    [SerializeField] [Range(1f, 15f)] float initialPower = 7f;
    [Space]

    [Header("EVENTS")]
    [SerializeField] Event gameOverEvent;

    List<GameObject> pool = new List<GameObject>();
    Vector2 defaultPos = new Vector2(0, -4);

    int[] validAngles = { 15, 30, 45, 60, 75, 120, 135, 150, 165 };

    bool _chekForGameOver = true;

    public int CurrentActiveBalls { get; private set; }
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        ballPrefab.transform.position = defaultPos;

        // Populate the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject currentBall = Instantiate(ballPrefab, this.transform);
            currentBall.SetActive(false);
            pool.Add(currentBall);
        }

        EnableBall(defaultPos);
    }

    private void Update()
    {
        if (!_chekForGameOver)
            return;

        // If all the ball are destroyed, end the game
        foreach (var ball in pool)
        {
            if (ball.activeInHierarchy)
                break;

            _chekForGameOver = false;
            gameOverEvent.RaiseEvent();
            break;
        }
    }
    #endregion

    #region Functions
    // Event listener of EnableBall
    public void EnableBall(Vector2 spawnPos)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy)
                continue;

            pool[i].transform.position = spawnPos;
            pool[i].SetActive(true);
            AddForceAngle(pool[i]);

            CurrentActiveBalls++;
            return;
        }
    }

    void AddForceAngle(GameObject ball)
    {
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        float angle = validAngles[Random.Range(0, validAngles.Length)];

        if (angle < 0 || angle > 360)
            return;

        float xValue = Mathf.Cos(angle * Mathf.Deg2Rad) * initialPower;
        float yValue = Mathf.Sin(angle * Mathf.Deg2Rad) * initialPower;

        rb.velocity = new Vector2(xValue, yValue);
    }
    #endregion
}
