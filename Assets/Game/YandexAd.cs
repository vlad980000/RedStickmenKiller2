using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class YandexAd : MonoBehaviour
{
    [SerializeField] private AdsStand _adsStand;

    [SerializeField] private PlayerWallet _playerWallet;

    [SerializeField] private int _reward;

    [SerializeField] private TimeManager _timeManager;

    [SerializeField] private Game _game;

    public event UnityAction Shows;
    public event UnityAction Showed;
    public event UnityAction InterstitialShowed;

    private void OnEnable()
    {
        _game.RequestInterstitial += ShowInterstitial;
        _adsStand.AdRequest += OnAdRequest;
    }

    private void OnDisable()
    {
        _game.RequestInterstitial -= ShowInterstitial;
        _adsStand.AdRequest -= OnAdRequest;    
    }

    private void OnAdRequest()
    {
        VideoAd.Show(OnShow,OnReward,OnShowed);
    }

    private void ShowInterstitial()
    {
        InterstitialAd.Show(OnShow, OnShowedInterstitial);
    }

    private void OnShow()
    {
        Shows?.Invoke();
        _timeManager.StopTime();
    }

    private void OnReward()
    {
        _playerWallet.ApplyMoney(_reward);
    }

    private void OnShowed()
    {
        Showed?.Invoke();
        _timeManager.StartTime();
    }

    private void OnShowedInterstitial(bool isShowed)
    {
        InterstitialShowed?.Invoke();
        _timeManager.StartTime();
    }
}
