using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetInt(int index)
    {
        _animator.SetInteger("WEapon", index);
    }
}
