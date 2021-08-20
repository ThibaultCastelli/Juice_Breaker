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

    [Header("COMPONENTS")]
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] Animator animator;

    Rigidbody2D rb;

    // Easing
    float time;
    float startPos;
    float endPos;
    float animationTime;
    float newPos;

    float startRot;
    float endRot;
    float newRot;
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position.y + 10;
        endPos = transform.position.y;
        animationTime = Random.Range(0.5f, 0.9f);

        startRot = Random.Range(0f, 359f);
    }

    private void FixedUpdate()
    {
        // Easing
        time += Time.fixedDeltaTime;

        // Position
        newPos = Easing.ExpoEaseInOut(time, startPos, endPos - startPos, animationTime);
        rb.MovePosition(new Vector2(transform.position.x, newPos));

        // Rotation
        newRot = Easing.ExpoEaseInOut(time, startRot, endRot - startRot, animationTime);
        rb.rotation = newRot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Desactivate the brick and add time to next respawn
        rb.simulated = false;
        timeToRespawn++;

        animator.SetBool("isDead", true);
        explosionParticle.Play();

        if (timeToRespawn <= maxTimeToRespawn)
            StartCoroutine(RespawnBrick());
    }
    #endregion

    IEnumerator RespawnBrick()
    {
        yield return new WaitForSeconds(timeToRespawn);
        rb.simulated = true;
        animator.SetBool("isDead", false);
    }
}
