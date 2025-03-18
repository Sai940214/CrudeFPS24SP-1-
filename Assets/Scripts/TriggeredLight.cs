using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TriggeredLight : MonoBehaviour
{
    Light spotlight;


    private void Start()
    {
        spotlight = GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something touched me");
        spotlight.intensity = 100f;
    }

    private void OnTriggerExit(Collider other)
    {
        spotlight.intensity = 1.0f;
    }

}
