using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    #region Variables
    [Header("STATS")]
    [SerializeField] [Range(0f, 1f)] float reductionSpeed = 0.1f;

    Rigidbody2D rb;

    float _defaultPlayerWidth;
    float _currentPlayerWidth;

    float _timePassed;

    float _xBound;
    float _xMousePos;

    float _camWidth;

    // Easing
    float time;
    float animationTime = 0.9f;

    float startRot = 359;
    float endRot;
    float newRot;

    float endSizeY;
    float newSizeY;
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        endSizeY = transform.localScale.y;
    }

    private void Start()
    {
        _camWidth = ((Camera.main.orthographicSize) * Camera.main.aspect) - 0.4f;
        _defaultPlayerWidth = transform.localScale.x;
    }

    private void Update()
    {
        // Reduce the player's width over time
        _timePassed += Time.deltaTime * reductionSpeed;
        float newPlayerWidth = Mathf.Clamp(_defaultPlayerWidth - _timePassed, 1, _defaultPlayerWidth);
        transform.localScale = new Vector3(newPlayerWidth, transform.localScale.y, transform.localScale.z);
    }

    private void FixedUpdate()
    {
        // Easing
        time += Time.fixedDeltaTime;

        newRot = Easing.ExpoEaseOut(time, startRot, endRot - startRot, animationTime);
        rb.rotation = newRot;

        newSizeY = Easing.ExpoEaseOut(time, 0, endSizeY, animationTime);
        transform.localScale = new Vector3(transform.localScale.x, newSizeY, transform.localScale.z);

        // Get the width of the game object
        _currentPlayerWidth = transform.localScale.x / 2;
        _xBound = _camWidth - _currentPlayerWidth;

        // Get the mouse position and clamp it
        _xMousePos = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -_xBound, _xBound);

        // Easing function
        float newXPos = transform.position.x + ((_xMousePos - transform.position.x) * 0.5f);
        rb.MovePosition(new Vector2(newXPos, transform.position.y));
    }
    #endregion
}
