using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StopWall : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(1f, 0.7f).SetEase(Ease.Linear);
    }
}
