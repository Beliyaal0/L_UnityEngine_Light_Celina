using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightIntensityAndColorController : MonoBehaviour
{
    [SerializeField] private GameObject[] PointLights;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxIntensity = 5f;

    private void Start()
    {
        PointLights = GameObject.FindGameObjectsWithTag("PointLight");
    }
    private void Update()
    {
        foreach (GameObject LightObj in PointLights)
        {
            Light PointLight = LightObj.GetComponent<Light>();
            //PointLight.intensity = 20;
            float distance = Vector3.Distance(PointLight.transform.position, transform.position);
            float intensity = (1 - distance / maxDistance) * maxIntensity;

            if (distance < maxDistance)
            {
                PointLight.intensity = intensity;
            }
            else
            {
                PointLight.intensity = 0f;
            }    
        }
    }
}
