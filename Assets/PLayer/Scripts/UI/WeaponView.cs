using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private PLayerWeapons _player;

    [SerializeField] private WeaponPanel _weaponView;

    [SerializeField] private GameObject _conteiner;

    private void Start()
    {
        for (int i = 0; i < _player.Weapons.Count; i++)
            AddWeapon(_player.Weapons[i]);
    }

    private void AddWeapon(Weapon weapon)
    {
        if (weapon.IsBuyed == true & weapon is not Skill)
        {
            var view = Instantiate(_weaponView, _conteiner.transform);
            view.SetPLayerWeapons(_player.GetComponent<PLayerWeapons>());
            view.SetWeapon(weapon);
        }
        else
        {
            return;
        }
    }
}
