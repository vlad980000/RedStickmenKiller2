using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : Weapon
{
    [SerializeField] private List<WeaponSettings> _weaponSettings = new List<WeaponSettings> ();

    [SerializeField] private int _currentLevel;
    
    [SerializeField] private WeaponSettings _currentWeaponSettings;

    protected float Recharge;

    private float _time = 0;

    protected void CountTime()
    {
        _time += Time.deltaTime;

        if (_time >= Recharge)
        {
            Shoot();
            _time = 0;
        }
    }
}
