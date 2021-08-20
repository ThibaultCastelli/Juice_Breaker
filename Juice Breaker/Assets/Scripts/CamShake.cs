using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [Header("SMALL SHAKE")]
    [SerializeField] [Range(0f, 5f)] float timeSmall = 0.3f;
    [SerializeField] [Range(0f, 5f)] float forceSmall = 0.3f;
    [Space]

    [Header("NORMAL SHAKE")]
    [SerializeField] [Range(0f, 5f)] float timeNormal = 0.5f;
    [SerializeField] [Range(0f, 5f)] float forceNormal = 0.5f;
    [Space]

    [Header("BIG SHAKE")]
    [SerializeField] [Range(0f, 5f)] float timeBig = 0.7f;
    [SerializeField] [Range(0f, 5f)] float forceBig = 1f;
    [Space]

    Vector3 defaultPos = new Vector3(0, 0, -10);

    public void SmallShake()
    {
        Shake(timeSmall, forceSmall); 
    }

    public void NormalShake()
    {
        Shake(timeNormal, forceNormal);
    }

    public void BigShake()
    {
        Shake(timeBig, forceBig);
    }

    void Shake(float time, float force)
    {
        transform.position = defaultPos;
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine(time, force));
    }

    IEnumerator ShakeCoroutine(float time, float force)
    {
        float t = time;

        while (t > 0)
        {
            t -= Time.deltaTime;

            float xNewPos = Random.Range(-force, force);
            float yNewPos = Random.Range(-force, force);

            transform.position = new Vector3(xNewPos, yNewPos, -10);

            yield return null;
        }

        transform.position = defaultPos;
    }
}
