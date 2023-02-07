using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFiller : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Stand _stand;

    private Weapon _weapon;

    private Coroutine _coroutine;
    private void OnEnable()
    {
        _stand = GetComponent<Stand>();
        _stand.ValueIsChanged = OnValueIsChanged;
    }

    private void OnValueIsChanged(float cost,float maxCost)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeValue((float)cost, (float)maxCost));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeValue((float)cost, (float)maxCost));
        }
    }

    private IEnumerator ChangeValue(float currentValue, float maxValue)
    {
        float targetValue = (float)currentValue / (float)maxValue;

        while (_image.fillAmount != targetValue)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, targetValue, 0.1f);
            yield return null;
        }
        yield break;
    }
}
