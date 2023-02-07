using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.WebUtility;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    const string LevelIndex = "LevelIndex";
    const string PlayerMoney = "PlayerMoney";

    [SerializeField] private Player _player;
    [SerializeField] private PlayerWallet _playerWallet;

    [SerializeField] private LevelReloader _levelReloader;

    [SerializeField] private EnemyCreator _enemyCreator;

    [SerializeField] private Data _data;

    [SerializeField] private SDKInitializer _sdkInitializer;

    [SerializeField] private SavingPLayerScore _savingPLayerScore;
    [SerializeField] private LoadingLeaderboard _loadingLeaderboard;

    [SerializeField] private GameObject _settingsPanel;

    [SerializeField] private YandexAd _yandexAd;

    [SerializeField] private ApplicationFocusChecker _applicationFocusChecker;

    [SerializeField] private GameObject _restartMenu;

    public UnityAction RequestInterstitial;

    public int Money => _playerWallet.Money;

    public int CurrentLevel => PlayerPrefs.GetInt(LevelIndex) + 1;

    private void Start()
    {
        _applicationFocusChecker.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        SetMoney();

        _sdkInitializer.PlayerAuthorizated += OnPlayerAuthorizated;
        _levelReloader.LevelCompleted += OnLevelCompleted;
        _yandexAd.InterstitialShowed += OnIntercticialIsShowed;
        _player.PLayerIsDied += OnPLayerIsDied;

        _enemyCreator.StartCoroutineEnemyes(PlayerPrefs.GetInt(LevelIndex));
    }

    private void OnDisable()
    {
        _sdkInitializer.PlayerAuthorizated -= OnPlayerAuthorizated;
        _levelReloader.LevelCompleted -= OnLevelCompleted;
        _yandexAd.InterstitialShowed -= OnIntercticialIsShowed;
        _player.PLayerIsDied -= OnPLayerIsDied;

        PlayerPrefs.SetInt(PlayerMoney, _player.Money);
    }

    public void OnRestartButtonKlick()
    {
        RequestInterstitial?.Invoke();
    }

    private void OnPlayerAuthorizated()
    {
        _savingPLayerScore.enabled = true;
        _loadingLeaderboard.enabled = true;
    }

    private void SetMoney()
    {
        if (PlayerPrefs.GetInt(PlayerMoney) != 0)
            _player.GetComponent<PlayerWallet>().ApplyMoney(PlayerPrefs.GetInt(PlayerMoney));
    }

    private void OnPLayerIsDied()
    {
        _restartMenu.gameObject.SetActive(true);
    }

    private void OnLevelCompleted()
    {
        if (PlayerPrefs.GetInt(LevelIndex) < _enemyCreator.LevelCount - 1)
            PlayerPrefs.SetInt(LevelIndex, PlayerPrefs.GetInt(LevelIndex) + 1);
        else
            PlayerPrefs.SetInt(LevelIndex, 0);

        RequestInterstitial?.Invoke();
    }

    private void OnIntercticialIsShowed()
    {
        SceneManager.LoadScene("MainScene");
    }
}
