using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] float timeToRespawn = 2f;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Color defaultColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.simulated = false;
        sprite.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
        StartCoroutine(RespawnBrick());
    }

    IEnumerator RespawnBrick()
    {
        yield return new WaitForSeconds(timeToRespawn);
        rb.simulated = true;
        sprite.color = defaultColor;
    }
}
