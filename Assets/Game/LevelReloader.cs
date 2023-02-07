using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelReloader : Stand
{
    [SerializeField] private Player _player;

    [SerializeField] private float _reloadDelay;

    private float _currentReloadDelay;

    public UnityAction LevelCompleted;

    private void OnEnable()
    {
        _currentReloadDelay = _reloadDelay;
        ValueIsChanged?.Invoke(_currentReloadDelay, _reloadDelay);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if (_player.IsMoving == false)
            {
                _currentReloadDelay -= Time.deltaTime;
                ValueIsChanged?.Invoke(_currentReloadDelay, _reloadDelay);

                if (_currentReloadDelay <= 0)
                {
                    _currentReloadDelay = _reloadDelay;
                    LevelCompleted?.Invoke();
                    enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _currentReloadDelay = _reloadDelay;
            ValueIsChanged?.Invoke(_currentReloadDelay, _reloadDelay);
        }
    }
}
