using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    private Animator _animator;
    private NavMeshAgent _navMashAgent;
    private EnemyHealth _enemyHealth;
    private float _distanceToTarget = Mathf.Infinity;
    private bool _isProvoked = false;
    private float _turnSpeed = 10f;
    void Start()
    {
        _navMashAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (_enemyHealth.IsDead() == true)
        {
            enabled = false;
            _navMashAgent.enabled = false;
            return;
        }

        _distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (_isProvoked)
        {
            EnagegeTarget();
        }
        else if (_distanceToTarget < chaseRange)
        {
            _isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        _isProvoked = true;
    }

    private void EnagegeTarget()
    {
        FaceTarget();

        if (_distanceToTarget >= _navMashAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (_distanceToTarget < _navMashAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        _animator.SetBool("IsAttacking", false);
        _animator.SetTrigger("Move");
        _navMashAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        _animator.SetBool("IsAttacking", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
