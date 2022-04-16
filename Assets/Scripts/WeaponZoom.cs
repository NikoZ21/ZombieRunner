using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedinFOV = 20f;
    [SerializeField] float zoomedInSensitivity = 2f;
    [SerializeField] float zoomedOutSensitivity = 1f;

    private Camera _fpsCamera;
    private bool isZoomToggled = false;
    private RigidbodyFirstPersonController _fpsController;

    private void Start()
    {
        _fpsCamera = Camera.main;
        _fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
        if (_fpsController == null) { Debug.Log("it is null"); }
    }

    private void OnDisable()
    {
        Debug.Log("entered");
        isZoomToggled = false;
        _fpsCamera.fieldOfView = zoomedOutFOV;
        ChangeMouseSensitviry(zoomedOutSensitivity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomToggled == false)
            {
                isZoomToggled = true;
                _fpsCamera.fieldOfView = zoomedinFOV;
                ChangeMouseSensitviry(zoomedInSensitivity);
            }
            else
            {
                isZoomToggled = false;
                _fpsCamera.fieldOfView = zoomedOutFOV;
                ChangeMouseSensitviry(zoomedOutSensitivity);
            }
        }
    }

    private void ChangeMouseSensitviry(float sensitivity)
    {
        _fpsController.mouseLook.XSensitivity = sensitivity;
        _fpsController.mouseLook.YSensitivity = sensitivity;
    }
}
