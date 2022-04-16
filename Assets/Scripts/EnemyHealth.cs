using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    public bool isDead = false;
    private int _currentHealth;
    private Animator _animator;


    private void Start()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead == true) return;
        _animator.SetTrigger("Die");
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
