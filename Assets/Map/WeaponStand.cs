using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Lean.Localization;

public class WeaponStand : Stand
{
    [SerializeField] private Weapon _weapon;

    [SerializeField] private LeanPhrase _buyPhrase;
    [SerializeField] private LeanPhrase _maximumPhrase;
    [SerializeField] private LeanPhrase _levelPhrase;

    private Player _player;

    private WeaponStats _weaponStats;

    public Weapon Weapon => _weapon;

    private void OnEnable()
    {
        _weapon.StatsIsSeted += OnStatsIsSeted;
        _weaponStats = _weapon.GetComponent<WeaponStats>();
        StartAnimation();
        SetName();
        SetCurrentLevel();
        ValueIsChanged?.Invoke(_weapon.WeaponStats.CurrentCostLevel, _weapon.WeaponStats.CostNextLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        SetCurrentPrice();
        CoroutineValue = _weaponStats.CurrentSettings.CoroutineValue;
        
        if (_player.IsMoving == false)
        {
            if(_weapon.IsBuyed == true)
            {
                SetCurrentLevel();

                foreach (var weapon in _player.PlayerWeapons.Weapons )
                {
                    if (weapon == _weapon)
                    {
                        if (weapon.WeaponStats.CurrentCostLevel <= 0)
                        {
                            weapon.Upgrade();
                            Level.text = (weapon.WeaponStats.CurrentLevel + 1).ToString();
                        }
                        else if (_player.PlayerWallet.CheckRemoveMoney(CoroutineValue) == true)
                        {
                            if(weapon.WeaponStats.CheckLevel() == true)
                            {
                                _player.PlayerWallet.RemoveMoney(CoroutineValue);
                                weapon.WeaponStats.RemoveCostValue(CoroutineValue);
                                ValueIsChanged?.Invoke(weapon.WeaponStats.CurrentCostLevel, weapon.WeaponStats.CostNextLevel);
                                weapon.SetCost(weapon.WeaponStats.CurrentCostLevel);
                                Debug.Log(weapon.WeaponStats.CurrentCostLevel);
                            }
                        }
                        else
                        {
                            return;
                        }
                        SetCurrentLevel();
                    }
                }
            }
            else
            {
                foreach (var weapon in _player.PlayerWeapons.Weapons)
                {
                    if (weapon == _weapon)
                    {
                        if (weapon.WeaponStats.CurrentCostLevel <= 0)
                        {
                            weapon.Buy();
                            Level.text = (weapon.WeaponStats.CurrentLevel + 1).ToString();
                        }
                        else if (_player.PlayerWallet.CheckRemoveMoney(CoroutineValue) == true )
                        {
                            if (weapon.WeaponStats.CheckLevel() == true)
                            {
                                _player.PlayerWallet.RemoveMoney(CoroutineValue);
                                weapon.WeaponStats.RemoveCostValue(CoroutineValue);
                                ValueIsChanged?.Invoke(weapon.WeaponStats.CurrentCostLevel, weapon.WeaponStats.CostNextLevel);
                                weapon.SetCost(weapon.WeaponStats.CurrentCostLevel);

                                if (weapon.WeaponStats.CurrentCostLevel == 0)
                                {
                                    weapon.Buy();
                                    Level.text = (weapon.WeaponStats.CurrentLevel + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        SetCurrentLevel();
                    }
                }
            }
        }
    }

    private void OnStatsIsSeted()
    {
        SetCurrentLevel();
        SetCurrentPrice();
    }

    private void SetCurrentPrice()
    {
        if (_weapon.IsBuyed == false)
        {
            CurrentCost.text = _weapon.WeaponStats.CurrentCostLevel.ToString();
            ValueIsChanged?.Invoke(_weapon.WeaponStats.CurrentCostLevel, _weapon.WeaponStats.CostNextLevel);
        }
        else if (_weapon.WeaponStats.CheckLevel() == false)
        {
            CurrentCost.text = LeanLocalization.GetTranslationText(_maximumPhrase.name);
            ValueIsChanged?.Invoke(1, 1);
        }
        else
        {
            CurrentCost.text = _weapon.WeaponStats.CurrentCostLevel.ToString();
            ValueIsChanged?.Invoke(_weapon.WeaponStats.CurrentCostLevel, _weapon.WeaponStats.CostNextLevel);
        }
    }

    private void SetName() { Name.text = _weapon.name; }

    private void SetCurrentLevel()
    {
        if (_weapon.WeaponStats.CurrentLevel == 0)
            Level.text = LeanLocalization.GetTranslationText(_buyPhrase.name);
        else
            Level.text = LeanLocalization.GetTranslationText(_levelPhrase.name) + "-" +_weapon.WeaponStats.CurrentLevel.ToString();
    }
}
