using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTransition : Transition
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Base>())
            NeedTransit = true;
    }
}
