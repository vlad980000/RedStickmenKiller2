using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlameThrower : Weapon
{
    public const string FlameThrowerLevel = "FlameThrowerLevel";
    public const string FlameThrowerCost = "FlameThrowerCurrentCost";
    public const string FlameThrowernIsBuyed = "FlameThrowerIsBuyed";

    [SerializeField] private ParticleSystem _flame;

    private List<Enemy> _enemyes = new List<Enemy>();

    private Collider _collider;

    private void OnEnable()
    {
        _flame.Play();
        SetRigWeight();
        SetStats(PlayerPrefs.GetInt(FlameThrowerLevel), PlayerPrefs.GetInt(FlameThrowerCost));
        GetIsBuyed();
    }

    private void OnDisable()
    {
        SetRigWeight();
    }
    public override void Upgrade()
    {
        TryUpgrade(FlameThrowerLevel,FlameThrowerCost);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
            _enemyes.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
            _enemyes.Remove(enemy);
    }

    public override void Shoot()
    {
        for (int i = 0; i < _enemyes.Count; i++)
        {
            if(_enemyes[i] != null && _enemyes[i].IsAlive == true)
                _enemyes[i].ApplyDamage(Damage);
            else
                _enemyes.RemoveAt(i);
        }
    }

    public override void SetCost(int cost)
    {
        PlayerPrefs.SetInt(FlameThrowerCost, cost);
    }

    public override int GetCost()
    {
        return PlayerPrefs.GetInt(FlameThrowerCost);
    }
}
