using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    private const string Audio = "Audio";
    private const string FirstStart = "FirstStart";
    private const string Sensitivity = "Sensitivity";

    [SerializeField] private FirstStartChecker _firstStartChecker;

    [SerializeField] private Player _player;

    [SerializeField] private EnemyCreator _enemyCreator;

    [SerializeField] GameObject _tutorial;

    [SerializeField] private GameObject _musicButtonOn;
    [SerializeField] private GameObject _musicButtonOff;

    [SerializeField] private Slider _sliderSensitivity;
    public bool IsFirstStart => PlayerPrefs.GetInt(FirstStart) == 1 ? false : true;

    public bool IsMusicOn => PlayerPrefs.GetInt(Audio) == 1 ? false : true;

    private void OnEnable()
    {
        _firstStartChecker.Started += OnFirstStart;

        _musicButtonOff.SetActive(IsMusicOn == true ? true : false) ;
        _musicButtonOn.SetActive(IsMusicOn == true ? false : true) ;

        _tutorial.SetActive(IsFirstStart);

        if (PlayerPrefs.GetFloat(Sensitivity) == 0)
            return;
        else
            _sliderSensitivity.value = PlayerPrefs.GetFloat(Sensitivity);
    }

    private void OnDisable()
    {
        _firstStartChecker.Started -= OnFirstStart;
        PlayerPrefs.SetFloat(Sensitivity, _sliderSensitivity.value);
    }

    public void SetMusicBool(bool isMusicOn)
    {
        PlayerPrefs.SetInt(Audio, isMusicOn == false ? 1 : 0);
    }

    private void OnFirstStart()
    {
        PlayerPrefs.SetInt(FirstStart,1);
    }
}
