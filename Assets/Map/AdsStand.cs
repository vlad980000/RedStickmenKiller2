using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
using Lean.Localization;

public class AdsStand : Stand
{
    [SerializeField] private float _adsDelay;
    [SerializeField] private float _currentTime = 0;
    [SerializeField] private float _reloadAdTime;

    [SerializeField] Image _image;
    
    [SerializeField] private PlayerWallet _playerWallet;

    [SerializeField] private LeanPhrase _timePhrase;
    
    private float _currentReloadAdTime;

    private Player _player;

    private bool _isCanShowAd = true;

    public UnityAction AdRequest;

    private void OnEnable()
    {
        StartAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _currentTime = _adsDelay;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_player.IsMoving == false && _isCanShowAd == true)
        {
            _currentTime -= Time.deltaTime;
            ValueIsChanged?.Invoke(_currentTime ,_adsDelay);

            if (_currentTime <= 0)
            {
                _isCanShowAd = false;
                StartCoroutine(AdReload());
                _currentTime = _adsDelay;
                AdRequest?.Invoke();
            }
        }
        else
        {
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() && _isCanShowAd == true)
        {
            _currentTime = _adsDelay;
            ValueIsChanged?.Invoke(_currentTime, _adsDelay);
        }
    }

    private IEnumerator AdReload()
    {
        _currentReloadAdTime = _reloadAdTime;
        _image.gameObject.SetActive(false);

        var waitOneSecond = new WaitForSeconds(1f);

        while (_reloadAdTime >= 0)
        {
            _currentReloadAdTime -= 1;
            CurrentCost.text = _currentReloadAdTime.ToString() + " " + LeanLocalization.GetTranslationText(_timePhrase.name);
            ValueIsChanged?.Invoke(_currentReloadAdTime, _reloadAdTime);
            yield return waitOneSecond;
        }
        _image.gameObject.SetActive(true);
        _isCanShowAd = true;
    }
}
