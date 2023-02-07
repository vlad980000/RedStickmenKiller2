using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    private float _sliderValue;

    private Coroutine _coroutine;

    protected void OnValueChanged(int value, int maxValue)
    {
        if (Slider.IsActive() == false)
            Slider.gameObject.SetActive(true);

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeValue(value, maxValue));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeValue(value, maxValue));
        }
    }

    protected void Start()
    {
        Slider.value = 1;
        Slider.gameObject.SetActive(false);
    }

    private IEnumerator ChangeValue(float currentValue, float maxValue)
    {
        float targetValue = (float)currentValue / (float)maxValue;

        while (Slider.value != targetValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, targetValue, 0.01f);
            yield return null;
        }
        yield break;
    }
}
