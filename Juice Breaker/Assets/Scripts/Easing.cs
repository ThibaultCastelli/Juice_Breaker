using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Easing
{
    public static float ExpoEaseOut(float t, float b, float c, float d)
    {
        return (t == d) ? b + c : c * (-Mathf.Pow(2, -10 * t / d) + 1) + b;
    }

    public static float ExpoEaseInOut(float t, float b, float c, float d)
    {
        if (t == 0)
            return b;

        if (t == d)
            return b + c;

        if ((t /= d / 2) < 1)
            return c / 2 * Mathf.Pow(2, 10 * (t - 1)) + b;

        return c / 2 * (-Mathf.Pow(2, -10 * --t) + 2) + b;
    }
}
