using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageDetection : MonoBehaviour
{
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string EnglishLanguage = "English";
    private const string RussianLanguage = "Russian";
    private const string TurkishLanguage = "Turkish";

    [SerializeField] private SDKInitializer _yandexInitialization;

    public bool IsDetected { get; private set; }

    private void OnEnable()
    {
        _yandexInitialization.Initialized += OnCompleted;
    }

    private void OnDisable()
    {
        _yandexInitialization.Initialized -= OnCompleted;
    }

    private void OnCompleted()
    {
        string language;

        switch (Agava.YandexGames.YandexGamesSdk.Environment.i18n.lang)
        {
            case EnglishCode:
                language = EnglishLanguage;
                break;
            case RussianCode:
                language = RussianLanguage;
                break;
            case TurkishCode:
                language = TurkishLanguage;
                break;
            default:
                language = EnglishLanguage;
                break;
        }

        Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language);
        Debug.Log(language);
        IsDetected = true;
    }
}
