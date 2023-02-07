using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public int Money => _money;

    public UnityAction MoneyIsChanged;

    public void ApplyMoney(int money)
    {
        _money += money;

        MoneyIsChanged?.Invoke();
    }

    public void RemoveMoney(int money)
    {
        if (_money - money >= 0)
        {
            _money -= money;

            MoneyIsChanged?.Invoke();
        }
        else
        {
            return;
        }
    }

    public bool CheckRemoveMoney(int money)
    {
        if (_money - money >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
