using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Data))]
public class FirstStartChecker : MonoBehaviour
{
    public event UnityAction Started;

    private void Start() => Started?.Invoke();
}
