using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class RoadState : State
{
    private const float Speed = 5;

    [SerializeField] private float _speed;
    [SerializeField] private Slider _slider;

    private Rigidbody _rigidbody;

    public bool IsMoving => _rigidbody.velocity.magnitude > 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void GoToBase()
    {
        transform.position = new Vector3(0,0,530);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var targetVectorX = new Vector3(_slider.value, 0 , 0);
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetVectorX.x, 0.8f),transform.position.y,transform.position.z);
        transform.position += new Vector3(0, 0,  Speed * Time.deltaTime);
    }
}
