using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Weapon))]
public class WeaponStats : MonoBehaviour
{
    [SerializeField] private List<WeaponSettings> _weaponSettings = new List<WeaponSettings>();
   
    [SerializeField] private WeaponSettings _startSettings;

    private Weapon _weapon;

    private int _costNextLevel;
    private int _currentCostNextLevel;
    private int _currentLevel;

    public WeaponSettings CurrentSettings => _startSettings; 

    public int CurrentCostLevel => _currentCostNextLevel;

    public int CurrentLevel => _currentLevel;

    public int CostNextLevel => _costNextLevel;
    
    public List<WeaponSettings> WeaponSettings => _weaponSettings;

    public UnityAction<int> StatsIsSet;

    private void OnEnable()
    {
        _weapon = GetComponent<Weapon>();
    }

    public WeaponSettings GetSettings(int index)
    {
        _startSettings = _weaponSettings[index];
        _costNextLevel = _startSettings.Cost;
        _currentLevel = _startSettings.Level;
        StatsIsSet?.Invoke(_currentLevel);
        return _startSettings;
    }

    public void SetCurrentCost(int cost)
    {
        if (cost == 0)
            _currentCostNextLevel = _costNextLevel;
        else
            _currentCostNextLevel = cost;
    }

    public void RemoveCostValue(int money)
    {
        _currentCostNextLevel -= money;
    }

    public bool CheckUpgrade(int money)
    {
        if(_currentCostNextLevel >= money)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckLevel()
    {
        if (_currentLevel < _weaponSettings.Count - 1)
            return true;
        else
            return false;
    }
}
