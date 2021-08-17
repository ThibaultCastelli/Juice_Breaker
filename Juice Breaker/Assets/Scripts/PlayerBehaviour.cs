using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float reductionSpeed = 0.1f;
    Rigidbody2D rb;

    float _defaultPlayerWidth;
    float _currentPlayerWidth;

    float _timePassed;

    float _xBound;
    float _xMousePos;

    float _camWidth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _camWidth = ((Camera.main.orthographicSize) * Camera.main.aspect);
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
        // Get the width of the game object
        _currentPlayerWidth = transform.localScale.x / 2;
        _xBound = _camWidth - _currentPlayerWidth;

        // Get the mouse position and clamp it
        _xMousePos = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -_xBound, _xBound);
        
        rb.MovePosition(new Vector2(_xMousePos, transform.position.y));
    }
}
