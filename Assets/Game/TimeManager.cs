using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool TimeIsPlayed => Time.time > 0;

    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    public void StopTime()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0;
        else
            return;
    }

    public void StartTime()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
        else
            return;
    }
}
