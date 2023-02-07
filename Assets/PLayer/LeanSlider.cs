using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.UI;

public class LeanSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _sliderSettings;

    private float _dividionNumber = 30;

    public LeanFinger LeanFinger;

    private void OnEnable()
    {
        _dividionNumber = _sliderSettings.value;
    }

    public void SetSensitivity(float value)
    {
        _dividionNumber = value;
    }

    public void ChangeSlideValue(Vector2 vector)
    {
        if (Time.timeScale == 0)
            return;

        var x = vector.x / _dividionNumber;

        _slider.value += x;
    }
}
