using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Skill
{
    private static string GrenadeLevel = "GrenadeLevel";
    private static string GrenadeCost = "GrenadeCost";
    private static string GrenadeIsBuyed = "GrenadeIsBuyed";

    [SerializeField] private Bomb _bomb;
    [SerializeField] private Collider _grenadeCollider;

    private void OnEnable()
    {
        SetStats(PlayerPrefs.GetInt(GrenadeLevel), PlayerPrefs.GetInt(GrenadeCost));
        GetIsBuyed();
        _bomb.gameObject.SetActive(false);
    }

    public override void SetCost(int cost)
    {
        PlayerPrefs.SetInt(GrenadeCost, cost);
    }

    public override void Shoot()
    {
        var bomb = Instantiate(_bomb,transform.position,Quaternion.identity);
        bomb.SetStats(Damage);
        bomb.transform.position = transform.position;
        bomb.gameObject.SetActive(true);
    }

    public override void Upgrade()
    {
        TryUpgrade(GrenadeLevel, GrenadeCost);
    }

    public override void Buy()
    {
        base.Buy();
        PlayerPrefs.SetInt(GrenadeIsBuyed, 1);
    }

    public override int GetCost()
    {
        return PlayerPrefs.GetInt(GrenadeCost);
    }
}
