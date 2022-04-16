using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHealth;
    private int _currenthHealth;
    private DeathHandler _deathHandler;


    void Start()
    {
        _currenthHealth = maxHealth;
        _deathHandler = FindObjectOfType<DeathHandler>();
    }

    public void TakeDamage(int damage)
    {
        _currenthHealth -= damage;
        Debug.Log(_currenthHealth);
        if (_currenthHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _deathHandler.HandleDeath();
    }
}
