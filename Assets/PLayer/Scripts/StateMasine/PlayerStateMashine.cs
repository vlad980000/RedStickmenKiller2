using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMashine : StateMashine
{
    private void Start()
    {
        Reset(FirstState);
    }

    private void Update()
    {
        CheckNextStateReady();
    }
}
