using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class LoadingLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Test";
    private const string Anonymous = "Anonimus";

    private List<LeaderboardPlayer> _players = new List<LeaderboardPlayer>();

    public LeaderboardPlayer[] Players => _players.ToArray();

    private void OnEnable()
    {
        Debug.Log("Лидерборд включился");

        _players = new List<LeaderboardPlayer>();

        Leaderboard.GetEntries((LeaderboardName), (result) =>
        {
            foreach(var entry in result.entries)
            {
                LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer();

                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = Anonymous;

                leaderboardPlayer.SetValue(name,entry.rank, entry.score);
                Debug.Log($"Добавляю плеера/ Имя - {name}| Место - {entry.rank}|Рекорд - {entry.score}");
                _players.Add(leaderboardPlayer);
            }
        });
    }
}
