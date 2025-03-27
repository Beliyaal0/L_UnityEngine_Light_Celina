using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lightrig : MonoBehaviour
{
    public float minIntensity = .5f;
    public float maxIntensity = 3f;
    public float flickerSpeed = .5f;
    private void Update()
    {
        float noise = Mathf.PerlinNoise(1, Time.time * flickerSpeed);
        GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        transform.rotation = Quaternion.Euler(0, noise, 0);
    }
}
