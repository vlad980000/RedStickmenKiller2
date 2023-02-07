using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    public void Animation()
    {
        transform.DOScaleY(0, 0.7f).SetEase(Ease.Linear);
    }
}
