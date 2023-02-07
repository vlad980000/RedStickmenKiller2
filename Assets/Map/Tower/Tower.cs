using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tower : MonoBehaviour
{
    [SerializeField] private UpperPart _upperPart;
    [SerializeField] private Player _player;

    private BaseState _playerBaseState;
    private List<Enemy> _enemyList = new List<Enemy>();

    private bool _isCanKill = true;

    private void OnEnable()
    {
        _playerBaseState = _player.GetComponent<BaseState>();
        _upperPart.EnemyIsKilled += OnEnemyIsKilled;
    }

    private void FixedUpdate()
    {
        if(_enemyList.Count > 0 & _isCanKill == true)
        {
            _isCanKill = false;
            StartKillEnemyes();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
            if(enemy.IsTarget == false)
            {
                enemy.SetIsTarget();
                _enemyList.Add(enemy);
            }
    }

    private void StartKillEnemyes()
    {
        _upperPart.KillEnemy(GetEnemy());
    }

    private void OnEnemyIsKilled(Enemy enemy)
    {
        _enemyList.Remove(enemy);
        _isCanKill = true;
    }

    private Enemy GetEnemy()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            if( _enemyList[i] != null)
                return _enemyList[i];
            else
                _enemyList.Remove(_enemyList[i]);
        }

        return null;
    }
}
