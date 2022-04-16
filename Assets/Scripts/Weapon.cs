using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Transform effects;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots;
    [SerializeField] TextMeshProUGUI ammoText;

    private Camera _FPCamera;
    private bool _canShoot = true;

    private void Start()
    {
        _FPCamera = Camera.main;
    }

    private void OnEnable()
    {
        _canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1") && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProccessRayCast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }


    private void ProccessRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                Debug.Log("we hit the enemy");
                target.TakeDamage(damage);
            }
            else
            {
                return;
            }
        }
    }


    public void CreateHitImpact(RaycastHit hit)
    {
        var _hitEffect = Instantiate(hitEffect, hit.transform.position, Quaternion.identity, effects);
        Destroy(_hitEffect, 0.1f);
    }
}