using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowMouse : MonoBehaviour
{
    Rigidbody2D rb;
    
    float playerWidth;
    float xBound;
    float xMousePos;

    float camWidth;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        camWidth = ((Camera.main.orthographicSize) * Camera.main.aspect);
    }

    private void FixedUpdate()
    {
        // Get the width of the game object
        playerWidth = transform.localScale.x / 2;
        xBound = camWidth - playerWidth;

        // Get the mouse position and clamp it
        xMousePos = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -xBound, xBound);
        
        rb.MovePosition(new Vector2(xMousePos, transform.position.y));
    }
}
