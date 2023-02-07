using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyTrigger>())
            NeedTransit = true;
    }
}
