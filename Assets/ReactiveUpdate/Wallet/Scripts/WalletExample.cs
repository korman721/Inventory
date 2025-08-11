using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private CurrencyType _currentType;
    [SerializeField] private int _addCount;
    [SerializeField] private int _removeCount;

    [SerializeField] private Sprite _diamondSprite;
    [SerializeField] private Sprite _coinSprite;
    [SerializeField] private Sprite _energySprite;

    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    private Dictionary<CurrencyType, ReactiveVariable<int>> _currencyTypeValue;

    private Dictionary<CurrencyType, Sprite> _currencyIcons;

    private void Awake()
    {
        _currencyTypeValue = new Dictionary<CurrencyType, ReactiveVariable<int>>
        {
            {CurrencyType.Coin, new ReactiveVariable<int>(0)}, 
            {CurrencyType.Diamond, new ReactiveVariable<int>(0)},
            {CurrencyType.Energy, new ReactiveVariable <int>(0)}
        };

        _currencyIcons = new Dictionary<CurrencyType, Sprite>()
        {
            {CurrencyType.Coin, _coinSprite}, {CurrencyType.Diamond, _diamondSprite}, {CurrencyType.Energy, _energySprite}
        };

        _wallet = new Wallet(_currencyTypeValue);
        _walletView.Initialize(_wallet, _currencyIcons);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            AddCurrency(_currentType, _addCount);

        if (Input.GetKeyDown(KeyCode.F))
            RemoveCurrency(_currentType, _removeCount);
    }

    private void AddCurrency(CurrencyType type, int addCount) => _wallet.AddCurrency(type, addCount);

    private void RemoveCurrency(CurrencyType type, int removeCount) => _wallet.RemoveCurrency(type, removeCount);
}
