using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PLayerWeapons))]
public class BaseState : State
{
    private const float Speed = 10;

    [SerializeField] private float _speed;

    [SerializeField] private Joystick _joystick;

    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _HPbar;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _wall;

    [SerializeField] private Finish _finish;

    [SerializeField] private Collider _baseCollider;

    [SerializeField] private GameObject _weaponView;

    [SerializeField] private CinemachineVirtualCamera _camera;

    private Rigidbody _rigidbody;

    private PLayerWeapons _playerWeapons;

    public UnityAction BaseIsReached;
    private float _normalizedSpeedHorisontale => _joystick.Horizontal * _speed * Time.deltaTime;
    private float _normalizedSpeedVerticale => _joystick.Vertical * _speed * Time.deltaTime;

    private bool _isCanMove = true;

    public bool IsMoving => (_joystick.Horizontal > 0.1 | _joystick.Horizontal < -0.1) || (_joystick.Vertical > 0.1 | _joystick.Vertical < -0.1);

    private void OnEnable()
    {
        _joystick.gameObject.SetActive(true);    
        _slider.gameObject.SetActive(false);
        _camera.Priority = 11;
    }

    private void Start()
    {
        _HPbar.gameObject.SetActive(false);
        _weaponView.SetActive(false);
        BaseIsReached?.Invoke();
        _wall.SetActive(true);
        _finish.Animation();
        _baseCollider.enabled = true;

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerWeapons = GetComponent<PLayerWeapons>();

        _playerWeapons.DestroyWeapon();
        _playerWeapons.InvokeStatsInit();

        _animator.SetLayerWeight(0, 0);
        _animator.SetLayerWeight(1, 0);
        _animator.SetLayerWeight(2, 1);
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<StopWall>())
            _isCanMove = false;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<StopWall>())
            _isCanMove = true;
    }


    private void Move()
    {
        if (IsMoving == true & _isCanMove == true)
        {
            var direction = new Vector3(_normalizedSpeedHorisontale, 0, _normalizedSpeedVerticale );
            transform.position += direction;
            transform.rotation = Quaternion.LookRotation(direction);
            _animator.SetBool("IsMoving", IsMoving);

        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("IsMoving", IsMoving);
        }
    }
}
