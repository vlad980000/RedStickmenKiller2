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
        Debug.Log("���������� ����������");

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
            {
                Debug.Log("���������� ����");
                if (result.score < _playerMoney.Money)
                    Leaderboard.SetScore(LeaderboardName, _playerMoney.Money);
            }
            else
            {
                Debug.Log("��� ����������");
                Leaderboard.SetScore(LeaderboardName, _playerMoney.Money);
            }
        });
    }
}
