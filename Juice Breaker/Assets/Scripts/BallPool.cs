using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField] [Range(0, 30)] int defaultPoolSize = 10;
    [SerializeField] GameObject ballPrefab;

    [SerializeField] [Range(1f, 15f)] float initialPower = 7f;

    [SerializeField] Event gameOverEvent;

    List<GameObject> pool = new List<GameObject>();
    Vector2 defaultPos = new Vector2(0, -4);

    int[] validAngles = { 15, 30, 45, 60, 75, 120, 135, 150, 165 };

    private void Awake()
    {
        ballPrefab.transform.position = defaultPos;

        for (int i = 0; i < defaultPoolSize; i++)
        {
            GameObject currentBall = Instantiate(ballPrefab, this.transform);
            currentBall.SetActive(false);
            pool.Add(currentBall);
        }

        EnableBall(defaultPos);
    }

    private void Update()
    {
        foreach (var ball in pool)
        {
            if (ball.activeInHierarchy)
                break;

            gameOverEvent.RaiseEvent();
        }
    }

    // Give a method to call a new ball
    public void EnableBall(Vector2 spawnPos)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy)
                continue;

            pool[i].transform.position = spawnPos;
            pool[i].SetActive(true);
            AddForceAngle(pool[i]);
            return;
        }

        GameObject currentBall = Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation, this.transform);
        pool.Add(currentBall);
        AddForceAngle(currentBall);
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
}
