using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PLayerWeapons : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

    [SerializeField] private Transform _weaponTransform;

    [SerializeField] private PLayerAnimationController _playerAnimationController;

    private Weapon _currentWeapon;

    public List<Weapon> Weapons => _weapons;

    private void Start()
    {
        SetStartWeapon();
        InitSkillsAbillity();
    }

    public void InvokeStatsInit()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].gameObject.SetActive(true);
            _weapons[i].StatsInit();

            if (_weapons[i] is Skill)
                _weapons[i].gameObject.SetActive(true);
            else
                _weapons[i].gameObject.SetActive(false);
        }
    }

    public void DestroyWeapon()
    {
        _currentWeapon.gameObject.SetActive(false);

        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i] is Skill)
                _weapons[i].gameObject.SetActive(false);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        if( _currentWeapon != null)
            _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = weapon;
        _currentWeapon.gameObject.SetActive(true); 
        _currentWeapon.StartShoot();
    }

    private void InitSkillsAbillity()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if(_weapons[i] is Skill && _weapons[i].IsBuyed == true)
                _weapons[i].StartShoot();   
        }
    }

    private void SetStartWeapon()
    {
        if(_weapons != null)
        {
            for (int i = 0; i < _weapons.Count; i++)
            {
                if (_weapons[i] is Skill)
                    _weapons[i].gameObject.SetActive(true);
                else
                    _weapons[i].gameObject.SetActive(false);
            }


            if (_currentWeapon != null)
                _currentWeapon.gameObject.SetActive(false);

            _currentWeapon = _weapons[0];
            _currentWeapon.gameObject.SetActive(true);
            _currentWeapon.StartShoot();

        }
    }
}
