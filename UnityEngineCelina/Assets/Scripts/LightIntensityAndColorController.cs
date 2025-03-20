using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightIntensityAndColorController : MonoBehaviour
{
    [SerializeField] private GameObject[] PointLights;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxIntensity = 5f;

    public Color startcolor = Color.red;
    public Color endcolor = Color.green;

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
                float colorRatio = 1 - (distance / maxDistance);
                PointLight.color = Color.Lerp(startcolor, endcolor, colorRatio);
            }
            else
            {
                PointLight.intensity = 0f;
                PointLight.color = startcolor;
            }    
        }
    }
}
