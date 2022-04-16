using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angletDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    private Light _flashLight;


    private void Start()
    {
        _flashLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        _flashLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (_flashLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            _flashLight.spotAngle -= angletDecay * Time.deltaTime;
        }
    }
}
