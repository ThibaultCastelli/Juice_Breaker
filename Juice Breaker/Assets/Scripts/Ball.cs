using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] [Range(1f, 15f)] float initialPower = 5f;
    [SerializeField] bool goUp;

    Rigidbody2D rb;
    float angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (goUp)
            angle = Random.Range(45f, 135f);
        else
            angle = Random.Range(0f, 360f);

        AddForceAngle(angle, initialPower);
    }

    void AddForceAngle(float angle, float force)
    {
        if (angle < 0 || angle > 360)
            return;

        float xValue = Mathf.Cos(angle * Mathf.Deg2Rad) * force;
        float yValue = Mathf.Sin(angle * Mathf.Deg2Rad) * force;

        rb.velocity = new Vector2(xValue, yValue);
    }
}
