using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class SavingPLayerScore : MonoBehaviour
{
    private const string LeaderboardName = "Test";

    [SerializeField] private PlayerWallet _playerMoney;

    public void OnEnable()
    {
        Debug.Log("Сохранения включились");

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
            {
                Debug.Log("Сохранения есть");
                if (result.score < _playerMoney.Money)
                    Leaderboard.SetScore(LeaderboardName, _playerMoney.Money);
            }
            else
            {
                Debug.Log("Нет сохранений");
                Leaderboard.SetScore(LeaderboardName, _playerMoney.Money);
            }
        });
    }
}
