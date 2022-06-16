using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackOfHay : MonoBehaviour
{
    [SerializeField] private GameObject[] _haysInStack;
    [SerializeField] private Transform _salePoint;
    [SerializeField] private HaySellingEffect _haySellengEffect;

    private int _haysInStackCount = 0;

    public void AddHayToStack()
    {
        _haysInStack[_haysInStackCount++].SetActive(true);
    }

    public void RemoveHayFromStack()
    {
        _haysInStack[--_haysInStackCount].SetActive(false);
        InstantiateSellingEffect(_haysInStack[_haysInStackCount].transform);



        if (_haysInStackCount < 0)
            _haysInStackCount = 0;
    }

    private void InstantiateSellingEffect(Transform startPoint)
    {
        var haySellingEfect = Instantiate(_haySellengEffect, startPoint.position, startPoint.rotation);
        haySellingEfect.SellingEffect(_salePoint);
    }
}
