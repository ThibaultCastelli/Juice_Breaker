using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallCollisions : MonoBehaviour
{
    #region Variables
    [Header("STATS")]
    [SerializeField] [Range(1f, 2f)] float accelrationStep = 1.1f;
    [SerializeField] [Range(10f, 30f)] float maxSpeed = 20f;
    [SerializeField] [Range(1, 10)] int brickBreakToSpawn = 4;
    [Space]

    [Header("COMPONENTS")]
    [SerializeField] ParticleSystem deathParticle;
    [Space]

    [Header("EVENTS")]
    [SerializeField] Event breakBrickEvent;
    [SerializeField] Event deathBallEvent;
    [SerializeField] Event touchBarreEvent;
    [SerializeField] EventVector2 enableBallEvent;

    Rigidbody2D rb;
    Vector2 lastVelocity;

    int currentBrickBreak = 0;
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }
    #endregion

    #region Triggers & Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 inDirection = lastVelocity;
        Vector2 inNormal = collision.GetContact(0).normal;

        Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal) * accelrationStep;
        float newVelocityX = Mathf.Clamp(newVelocity.x, -maxSpeed, maxSpeed);
        float newVelocityY = Mathf.Clamp(newVelocity.y, -maxSpeed, maxSpeed);

        rb.velocity = new Vector2(newVelocityX, newVelocityY);

        if (collision.transform.tag == "Brick")
        {
            breakBrickEvent.RaiseEvent();
            currentBrickBreak++;

            if (currentBrickBreak >= brickBreakToSpawn)
            {
                enableBallEvent.RaiseEvent(transform.position);
                currentBrickBreak = 0;
            }
        }

        // Audio
        if (collision.transform.tag == "Player")
            touchBarreEvent.RaiseEvent();
        else if (collision.transform.tag == "Wall")
            AudioManager.GetAudioPlayer("SFX_Coll_BallWall").Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
            StartCoroutine(deathCoroutine());
    }

    IEnumerator deathCoroutine()
    {
        deathBallEvent.RaiseEvent();
        deathParticle.Play();
        yield return new WaitUntil(() => !deathParticle.isPlaying);
        gameObject.SetActive(false);
    }
    #endregion
}
