using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthIsChanged += OnValueChanged;
        Start();
    }

    private void OnDisable() { _player.HealthIsChanged -= OnValueChanged; }
}
