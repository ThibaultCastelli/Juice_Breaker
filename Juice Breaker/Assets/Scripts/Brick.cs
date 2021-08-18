using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    #region Variables
    [Header("STATS")]
    [SerializeField] [Range(1f, 10f)] float timeToRespawn = 2f;
    [SerializeField] [Range(1f, 10f)] float maxTimeToRespawn = 10f;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Color defaultColor;
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Desactivate the brick and add time to next respawn
        rb.simulated = false;
        sprite.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
        timeToRespawn++;

        if (timeToRespawn <= maxTimeToRespawn)
            StartCoroutine(RespawnBrick());
    }
    #endregion

    IEnumerator RespawnBrick()
    {
        yield return new WaitForSeconds(timeToRespawn);
        rb.simulated = true;
        sprite.color = defaultColor;
    }
}
