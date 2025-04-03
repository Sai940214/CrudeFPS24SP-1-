using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static float Remap(float value, float oldMin, float oldMax,
        float newMin, float newMax)
    {
        return (value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;
    }

    public static float Remap01(float value, float oldMin, float oldMax)
    {
        return Utils.Remap(value, oldMin, oldMax, 0, 1);
    }
}
