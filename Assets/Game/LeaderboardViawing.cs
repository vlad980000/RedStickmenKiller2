using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class LeaderboardViawing : MonoBehaviour
{
    private const int PanelCount = 5;

    [SerializeField] private LoadingLeaderboard _yandexLeaderboardLoading;

    [SerializeField] private FillingPlayerData _yandexPlayerDataPrefab;

    [SerializeField] private GameObject _conteiner;

    private LeaderboardPlayer[] _players;

    private void OnEnable()
    {
        _players = _yandexLeaderboardLoading.Players;

        for (int i = 0; i < PanelCount; i++)
            CreatePLayerPanel(_players[i]);

        enabled = false;
    }

    private void CreatePLayerPanel(LeaderboardPlayer player)
    {
        var panel = Instantiate(_yandexPlayerDataPrefab, _conteiner.transform);
        panel.Set(player);
    }
}
