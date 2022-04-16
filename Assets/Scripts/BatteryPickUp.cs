using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private FlashLight _flashLight;
    private float _restoreAngle;
    private float _restoreIntensity;


    private void Start()
    {
        _flashLight = FindObjectOfType<FlashLight>();
        _restoreAngle = _flashLight.GetComponent<Light>().spotAngle;
        _restoreIntensity = _flashLight.GetComponent<Light>().intensity;
    }


    private void OnTriggerEnter(Collider other)
    {
        _flashLight.GetComponent<Light>().spotAngle = _restoreAngle;
        _flashLight.GetComponent<Light>().intensity = _restoreIntensity;
        Destroy(gameObject);
    }
}
