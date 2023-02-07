using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BaseState))]
[RequireComponent(typeof(PlayerWallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    [SerializeField] private float _speed;

    private BaseState _baseState;

    private PlayerWallet _playerWallet;

    private PLayerWeapons _playerWeapons;

    public bool IsMoving => _baseState.IsMoving;

    public int Money => _playerWallet.Money;

    public PlayerWallet PlayerWallet => _playerWallet;

    public BaseState BaseState => _baseState;

    public PLayerWeapons PlayerWeapons => _playerWeapons;

    public int MaxHealth { get; private set; }

    public int Health => _health;

    public UnityAction PLayerIsDied;

    public UnityAction StopCreateEnemy;

    public UnityAction<int , int> HealthIsChanged;

    private void Start()
    {
        MaxHealth = _health;
        _baseState = GetComponent<BaseState>();
        _playerWallet = GetComponent<PlayerWallet>();
        _playerWeapons = GetComponent<PLayerWeapons>();
    }

    public void ApplyDamage(int damage)
    {
        if(_health > damage)
        {
            _health -= damage;
            HealthIsChanged?.Invoke(_health,MaxHealth);
        }
        else
        {
            _health = 0;
            HealthIsChanged?.Invoke(_health, MaxHealth);
            PLayerIsDied?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StopCreateEnemyTrigger>())
            StopCreateEnemy?.Invoke();
    }
}
