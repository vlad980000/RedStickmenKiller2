using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMashine : StateMashine
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Enemy>().PLayer;
        Reset(FirstState);
    }

    private void Update()
    {
        CheckNextStateReady();
    }
}
