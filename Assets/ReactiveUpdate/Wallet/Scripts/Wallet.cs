using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private const int MaxValue = 100;

    public CurrencyType CurrencyType { get; private set; }

    private Dictionary<CurrencyType, ReactiveVariable<int>> _currencyTypeValue;

    public Wallet(Dictionary<CurrencyType, ReactiveVariable<int>> currencyTypeDictionary)
    {
        _currencyTypeValue = currencyTypeDictionary;
    }

    public IEnumerable<IReadOnlyVariable<int>> Values => _currencyTypeValue.Values;

    public void AddCurrency(CurrencyType type, int currencyCount)
    {
        if (currencyCount < 0)
            return;

        _currencyTypeValue.TryGetValue(type, out ReactiveVariable<int> value);
        CurrencyType = type;

        value.Value = Mathf.Clamp(value.Value + currencyCount, 0, MaxValue);
    }

    public void RemoveCurrency(CurrencyType type, int currencyCount)
    {
        if (currencyCount < 0)
            return;

        _currencyTypeValue.TryGetValue(type, out ReactiveVariable<int> value);
        CurrencyType = type;

        value.Value = Mathf.Clamp(value.Value - currencyCount, 0, MaxValue);
    }
}