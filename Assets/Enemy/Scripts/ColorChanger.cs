using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _targetColor;

    [SerializeField] private float _timeToChangeColor;

    private Renderer _renderer;

    private Material _baseColor;

    private Sequence _sequence;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _baseColor = _renderer.material;
    }

    public void ChangeColor() { _renderer.material = _targetColor; }

    public void LoopChangeColor() { StartCoroutine(StartLoopChangeColor()); }

    private IEnumerator StartLoopChangeColor()
    {
        var time = new WaitForSeconds(_timeToChangeColor);

        _renderer.material = _targetColor;

        yield return time;

        _renderer.material = _baseColor;
    }
}
