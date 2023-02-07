using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public const string ShotgunLevel = "ShotgunLevel";
    public const string ShotgunCost = "ShotgunCurrentCost";
    public const string ShotgunIsBuyed = "ShotgunIsBuyed";

    private const int BulletCount = 3;

    private void OnEnable()
    {
        SetRigWeight();
        SetStats(PlayerPrefs.GetInt(ShotgunLevel), PlayerPrefs.GetInt(ShotgunCost));
        GetIsBuyed();
        Debug.Log(IsBuyed);
    }

    private void OnDisable()
    {
        SetRigWeight(); 
    }

    public override void Upgrade()
    {
        TryUpgrade(ShotgunLevel, ShotgunCost);
    }

    public override void Buy()
    {
        base.Buy();
        PlayerPrefs.SetInt(ShotgunIsBuyed, 1);
    }

    public override void Shoot()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            if(i == 0)
            {
                var bullet = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.identity);
                bullet.SetStats(Damage, BulletLifetime, true);
            }
            else if(i == 1)
            {
                var bullet = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.Euler(0f,20f,0f));
                bullet.SetStats(Damage, BulletLifetime, true);
            }
            else if (i == 2)
            {
                var bullet = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.Euler(0f, -20f, 0f));
                bullet.SetStats(Damage, BulletLifetime, true);
            }
        }
    }

    public override void SetCost(int cost)
    {
        PlayerPrefs.SetInt(ShotgunCost, cost);
    }
}
