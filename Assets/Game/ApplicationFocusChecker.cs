using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFocusChecker : MonoBehaviour
{
    [SerializeField] private Game _game;

    [SerializeField] private TimeManager _timeManager;

    [SerializeField] private Sound _sound;

    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private GameObject _leaderboardPanel;

    [SerializeField] private Data _data;

    private void OnApplicationFocus(bool focus)
    {
        if (_tutorialPanel.gameObject.activeSelf == true && focus == false)
        {
            _sound.DisableAudio();
            return;
        }
        else if(focus == true && _data.IsMusicOn == true)
        {
            _sound.EnableAudio();
            return;
        }

        if (_leaderboardPanel.gameObject.activeSelf == true && focus == false)
        {
            _sound.DisableAudio();
            return;
        }
        else if (focus == true && _data.IsMusicOn == true)
        {
            _sound.EnableAudio();
            return;
        }

        if (focus == false && _settingsPanel.activeSelf == false)
        {
            _settingsPanel.SetActive(true);

            if(_data.IsMusicOn == true)
                _sound.DisableAudio();
        }
        else if(focus == false && _settingsPanel.activeSelf == true)
        {
            _settingsPanel.SetActive(true);

            if (_data.IsMusicOn == true)
                _sound.DisableAudio();
        }
        else if(focus == true && _settingsPanel.activeSelf == true)
        {
            if (_data.IsMusicOn == true)
                _sound.EnableAudio();

            return;
        }
        else if(focus == true && _settingsPanel.activeSelf == false)
        {
            if (_data.IsMusicOn == true)
                _sound.EnableAudio();

            return;
        }
    }
}
