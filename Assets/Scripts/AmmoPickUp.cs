using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    private Ammo _ammo;

    private void Start()
    {
        _ammo = FindObjectOfType<Ammo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            _ammo.AddAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
