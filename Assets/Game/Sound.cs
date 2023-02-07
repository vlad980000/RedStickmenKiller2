using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sound : MonoBehaviour
{
    private const float MaxValue = 1f;
    private const float MinValue = 0f;

    [SerializeField] private TimeManager _timeManager;

    [SerializeField] private Data _data;

    [SerializeField] private YandexAd _yandexAd;

    private MusicSelector _selectingMusic;

    public event UnityAction Changed;

    private void Start()
    {
        _selectingMusic = GetComponent<MusicSelector>();

        if(_data.IsMusicOn == true)
            EnableAudio();
    }

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        _yandexAd.Shows += OnAdShow;
        _yandexAd.Showed += OnAdShowed; 
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        _yandexAd.Shows -= OnAdShow;
        _yandexAd.Showed -= OnAdShowed;
    }

    public void DisableAudio()
    {
        AudioListener.pause = true;
        AudioListener.volume = MinValue;
        Changed?.Invoke();
    }

    public void EnableAudio()
    {
        if (_selectingMusic.CurrentMusic.gameObject.activeSelf == false)
            _selectingMusic.CurrentMusic.gameObject.SetActive(true);

        AudioListener.pause = false;
        AudioListener.volume = MaxValue;
        Changed?.Invoke();
    }

    private void OnAdShow()
    {
        DisableAudio();
    }

    private void OnAdShowed()
    {
        if (_data.IsMusicOn == true)
            EnableAudio();
        else
            return;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if (inBackground == true)
        {
            AudioListener.pause = true;
            AudioListener.volume = MinValue;
        }
        else if(inBackground == false & _data.IsMusicOn == true)
        {
            AudioListener.pause = false;
            AudioListener.volume = MaxValue;
        }
    }
}
