using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BigBullet : Skill
{
    public const string BigBulletLevel = "BigBulletLevel";
    public const string BigBulletCost = "BigBulletCurrentCost";
    public const string BigBulletIsBuyed = "BigBulletIsBuyed";

    [SerializeField] private Bullet _bullet;

    [SerializeField] private float _scale;
    [SerializeField] private float _lifeTime;

    private void OnEnable()
    {
        SetStats(PlayerPrefs.GetInt(BigBulletLevel), PlayerPrefs.GetInt(BigBulletCost));
        GetIsBuyed();
    }

    public override void Upgrade()
    {
        TryUpgrade(BigBulletLevel, BigBulletCost);
    }

    public override void Shoot()
    {
        var bullet = Instantiate(_bullet, ShootPoint.position, Quaternion.identity);
        bullet.transform.localScale = new Vector3(_scale, _scale, _scale);
        bullet.SetStats(Damage, _lifeTime, false);
    }

    public override void Buy()
    {
        base.Buy();
        PlayerPrefs.SetInt(BigBulletIsBuyed, 1);
    }

    public override void SetCost(int cost)
    {
        PlayerPrefs.SetInt(BigBulletCost, cost);
    }

    public override int GetCost()
    {
        return PlayerPrefs.GetInt(BigBulletCost);
    }
}
