#pragma warning disable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class YandexInitialization : MonoBehaviour
{
    private const string LeaderboardName = "Test";

    public event UnityAction PlayerAuthorizated;
    public event UnityAction Completed;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize(() => PlayerAccount.RequestPersonalProfileDataPermission());

        Completed?.Invoke();
        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
                PlayerAuthorizated?.Invoke();
        });
    }
}
