using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TimeManager _timeManager;

    private void Start() => _timeManager.StopTime();

    private void OnDisable() => _timeManager.StartTime();
}
