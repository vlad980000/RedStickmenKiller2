using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    private NavMeshAgent _navMeshAgent;

    private Enemy _enemy;

    private Player _player;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _player = GetComponent<Enemy>().PLayer;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (_player != null)
            _navMeshAgent.SetDestination(_player.transform.position);
    }
}
