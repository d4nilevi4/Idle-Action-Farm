using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HayFill : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        _slider.value = (float)_backpack.CurrentHaysCount / _backpack.MaxHaysCount;
    }
}
