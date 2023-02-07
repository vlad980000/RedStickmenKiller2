using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;
using UnityEngine.UI;
using Lean.Localization;

[RequireComponent(typeof(WeaponStats))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float BulletLifetime;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected Rig Rig;

    protected int Damage;

    [SerializeField] private WeaponStats _weaponStats;
    [SerializeField] private Sprite _face;
    [SerializeField] private string _name;
    [SerializeField] private Material _bulletColor;
    [SerializeField] private ParticleSystem _bulletEffect;
    [SerializeField] private bool _isBuyed;

    [SerializeField] private LanguageDetection _languageDetection;
    [SerializeField] private LeanPhrase _leanPhrase;

    private float _shootTime;

    public bool IsBuyed => _isBuyed;

    public string Name => _name;

    public Sprite Face => _face;

    public UnityAction StatsIsSeted;

    public WeaponStats WeaponStats => _weaponStats; 

    public abstract void Shoot();

    public abstract void Upgrade();

    public abstract void SetCost(int cost);

    public abstract int GetCost();

    public void StartShoot()
    {
        StartCoroutine(Shooting());
    }

    protected IEnumerator Shooting()
    {
        var time = new WaitForSeconds(_shootTime);

        while (true)
        {
            yield return time;
            Shoot();
        }
    }

    protected void SetStats(int index,int cost)
    {
        if (_languageDetection)
        {
            _name = Lean.Localization.LeanLocalization.GetTranslationText(_leanPhrase.name);
        }
        _weaponStats = GetComponent<WeaponStats>();
        _weaponStats.SetCurrentCost(cost);
        Damage = _weaponStats.GetSettings(index).Damage;
        _shootTime = _weaponStats.GetSettings(index).ShootTime;
        _weaponStats.SetCurrentCost(GetCost());
    }

    protected void SetRigWeight()
    {
        Rig.weight = Rig.weight == 0 ? 1 : 0;
    }

    protected void GetIsBuyed()
    {
        if (_weaponStats.CurrentLevel == 0)
            _isBuyed = false;
        else
            _isBuyed = true;
    }

    public void TryUpgrade(string level, string cost)
    {
        GetIsBuyed();

        if (PlayerPrefs.GetInt(level) == _weaponStats.WeaponSettings.Count - 1)
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt(level, PlayerPrefs.GetInt(level) + 1);
            PlayerPrefs.SetInt(cost, _weaponStats.WeaponSettings[PlayerPrefs.GetInt(level)].Cost);
            _weaponStats.SetCurrentCost(PlayerPrefs.GetInt(cost));
            _weaponStats.GetSettings(PlayerPrefs.GetInt(level));
        }
    }

    public void StatsInit()
    {
        StatsIsSeted?.Invoke();
    }

    public virtual void Buy()
    {
        if (_isBuyed == false)
        {
            Upgrade();
            _isBuyed = true;
        }
        else
            return;
    }
}
