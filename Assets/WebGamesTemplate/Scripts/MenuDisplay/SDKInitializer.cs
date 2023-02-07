#pragma warning disable

using System;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class SDKInitializer : MonoBehaviour
{
    private const string LeaderboardName = "Test";

    public event UnityAction Initialized;
    public event UnityAction PlayerAuthorizated;

    private bool initialized => YandexGamesSdk.IsInitialized;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize(() => PlayerAccount.RequestPersonalProfileDataPermission(Initialized.Invoke));

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
            {
                Debug.Log("Результат найден" + result);
                PlayerAuthorizated?.Invoke();
            }
            else
            {
                Debug.Log("Игрок не найден");
            }
        });
        Initialized?.Invoke();
    }

    private void OnYandexSDKInitialize()
    {
        Initialized?.Invoke();
    }
}
