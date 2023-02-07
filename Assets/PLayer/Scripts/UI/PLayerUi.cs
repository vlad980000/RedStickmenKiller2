using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class PLayerUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerMoney;
    [SerializeField] private TMP_Text _level;

    [SerializeField] private PlayerWallet _playerWallet;

    [SerializeField] private Game _game;

    [SerializeField] private LeanPhrase _levelPhrase;

    private int _currentMoney;

    private void OnEnable()
    {
        _playerWallet.MoneyIsChanged += OnMoneyIsChanged;
    }

    private void OnDisable()
    {
        _playerWallet.MoneyIsChanged -= OnMoneyIsChanged;
    }

    private void Start()
    {
        _currentMoney = _playerWallet.Money;
        _playerMoney.text = _currentMoney.ToString();
        _level.text = $"{Lean.Localization.LeanLocalization.GetTranslationText(_levelPhrase.name)} - {_game.CurrentLevel.ToString()}";
    }

    private void OnMoneyIsChanged()
    {
        if(_playerWallet.Money > _currentMoney)
            ApplyMoneyValue();
        else
            RemoveMoneyValue();
    }

    private void ApplyMoneyValue()
    {
        while(_currentMoney != _playerWallet.Money)
        {
            _currentMoney++;
            _playerMoney.text = _currentMoney.ToString();
        }
    }

    private void RemoveMoneyValue()
    {
        while (_currentMoney != _playerWallet.Money)
        {
            _currentMoney--;
            _playerMoney.text = _currentMoney.ToString();
        }
    }
}
