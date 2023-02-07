using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private TimeManager _timeManager;

    private void OnEnable() => _timeManager.StopTime();

    private void OnDisable() => _timeManager.StartTime();
}
