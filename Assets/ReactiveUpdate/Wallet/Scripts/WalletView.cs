using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currencyCount;
    [SerializeField] private Image _currencyIcon;

    [SerializeField] private Canvas _canvas;

    private Dictionary<CurrencyType, Sprite> _currencyIcons;

    private Wallet _wallet;

    public void Initialize(Wallet wallet, Dictionary<CurrencyType, Sprite> currencyIcons)
    {
        _canvas.gameObject.SetActive(true);

        _currencyIcons = currencyIcons;

        _wallet = wallet;

        foreach (var item in _wallet.Values)
            item.Changed += OnCurrencyChanged;
    }

    private void OnDestroy()
    {
        foreach (var item in _wallet.Values)
            item.Changed -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged(int newValue)
    {
        _currencyCount.text = $"Currency Value: {newValue}";
        _currencyIcon.sprite = _currencyIcons[_wallet.CurrencyType];
    }
}
