using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SecondSlideImageMover : MonoBehaviour
{
    [SerializeField] private GameObject _movePoint;

    [SerializeField] private float _duration;

    private void OnEnable()
    {

        Tween tween = transform.DOMove(_movePoint.transform.position, _duration).SetOptions(true).SetUpdate(UpdateType.Normal,true).SetLoops(-1, LoopType.Yoyo);
    }
}
