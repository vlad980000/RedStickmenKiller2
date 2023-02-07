using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Stand : MonoBehaviour
{
    [SerializeField] protected int CoroutineValue;

    [SerializeField] protected TMP_Text CurrentCost;
    [SerializeField] protected TMP_Text Name;
    [SerializeField] protected TMP_Text Level;

    [SerializeField] private GameObject _model;

    [SerializeField] private Transform _modelPosition;

    [SerializeField] private float _animationDuration;
    [SerializeField] private float _modelScale;

    public UnityAction<float, float> ValueIsChanged;

    protected void StartAnimation()
    {
        var model = Instantiate(_model, _modelPosition.transform.position, Quaternion.identity);
        model.transform.DOScale(_modelScale, _animationDuration);
        Tween tween = model.transform.DORotate(new Vector3(0f, 360f, 0f), _animationDuration, RotateMode.FastBeyond360);

        tween.SetEase(Ease.Linear).SetLoops(-1);
    }
}
