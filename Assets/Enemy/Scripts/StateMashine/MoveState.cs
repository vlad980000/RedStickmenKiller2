using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private NavMeshAgent _navMeshAgent;

    private Enemy _enemy;

    private Player _player;

    private Collider _collider;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _player = GetComponent<Enemy>().PLayer;
        _collider = GetComponent<Collider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_player != null)
            _navMeshAgent.SetDestination( new Vector3(transform.position.x,0,_player.transform.position.z));
    }
}
