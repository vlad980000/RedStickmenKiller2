using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _face;
    [SerializeField] private Button _button;

    private Weapon _weapon;

    private PLayerWeapons _playerWeapons;

    private void Start()
    {
        RendWeapon();
    }

    private void RendWeapon()
    {
        _name.text = _weapon.Name;
        _face.sprite = _weapon.Face;
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void SetWeaponInArm()
    {
        _playerWeapons.SetWeapon(_weapon);
    }

    public void SetPLayerWeapons(PLayerWeapons playerWeapons)
    {
        _playerWeapons = playerWeapons;
    }
}
