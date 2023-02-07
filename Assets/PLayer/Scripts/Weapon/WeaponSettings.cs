using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon settings", menuName = "Weapon Settings / Create new weapon", order = 51)]
public class WeaponSettings : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private int _cost;
    [SerializeField] private int _level;
    [SerializeField] private int _coroutineValue;

    [SerializeField] private float _shootTime;

    public int Damage => _damage;
    public int Cost => _cost;
    public int Level => _level;
    public int CoroutineValue => _coroutineValue;

    public float ShootTime => _shootTime;
}
