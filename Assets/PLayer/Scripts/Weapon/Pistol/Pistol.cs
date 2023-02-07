using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pistol : Weapon
{
    public const string PistolLevel = "PistolLevel";
    public const string CurrentCost = "PistolCurrentCost";

    private void OnEnable()
    {
        SetRigWeight();
        SetStats(PlayerPrefs.GetInt(PistolLevel),PlayerPrefs.GetInt(CurrentCost));
    }

    private void OnDisable()
    {
        SetRigWeight();
    }

    public override void Upgrade()
    {
        TryUpgrade(PistolLevel, CurrentCost);
    }

    public override void Shoot()
    {
        var bullet = Instantiate(Bullet,ShootPoint.transform.position,Quaternion.identity);

        bullet.SetStats(Damage, BulletLifetime,true);
    }

    public override void SetCost(int cost)
    {
        PlayerPrefs.SetInt(CurrentCost, cost);
    }

    public override int GetCost()
    {
        return PlayerPrefs.GetInt(CurrentCost);
    }
}
