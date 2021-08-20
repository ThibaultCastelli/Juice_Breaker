using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            StartCoroutine(KillParticle(Instantiate(collisionParticle, collision.transform.position, collision.transform.rotation, transform)));
        }
    }

    IEnumerator KillParticle(ParticleSystem particle)
    {
        particle.Play();
        yield return new WaitUntil(() => !particle.isPlaying);
        Destroy(particle.gameObject);
    }
}
