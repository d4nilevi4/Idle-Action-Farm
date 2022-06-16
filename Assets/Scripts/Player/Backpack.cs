using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private StackOfHay _stack;
    [SerializeField] private Wallet _wallet;

    [Header("Coin Effect")]
    [SerializeField] private CoinEffect _coinEffect;
    [SerializeField] private Transform _barnTranssform;
    [SerializeField] private Transform _coinUITransform;

    [Range(0, 40)]
    [SerializeField] private int _currentHaysCount;
    [SerializeField] private int _maxHaysCount;


    private bool _isFull = false;
    private bool _isEmpty = true;

    public bool IsFull => _isFull;
    public bool IsEmpty => _isEmpty;

    public int CurrentHaysCount => _currentHaysCount;
    public int MaxHaysCount => _maxHaysCount;

    public void AddHeysCount()
    {
        _currentHaysCount++;
        
        if (_currentHaysCount % 2 == 0)
        {
            _stack.AddHayToStack();
            if (_currentHaysCount == _maxHaysCount)
            {
                _isFull = true;
            }
        }

        _isEmpty = false;
    }

    public void SellHeysCount()
    {
        if (_currentHaysCount == 0)
        {
            _isEmpty = true;
            return;
        }

        if (_currentHaysCount % 2 == 0)
        {
            _stack.RemoveHayFromStack();
        }

        _wallet.AddCoins(Hay.cost);
        var coinEffect = Instantiate(_coinEffect, _barnTranssform.position, Quaternion.identity);
        coinEffect.CoinMoveEffect(_coinUITransform);

        _currentHaysCount--;

        _isFull = false;
    }
}
