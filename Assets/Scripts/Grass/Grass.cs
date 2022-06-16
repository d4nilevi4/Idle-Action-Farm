using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrassGrowth))]
public class Grass : MonoBehaviour
{
    [SerializeField] private GrassGrowth _grassGrowth;
    [SerializeField] private GameObject _hay;
    [SerializeField] private GrassTrigger _grassTrigger;

    private bool _canCollect;

    public bool CanCollect => _canCollect;

    private void OnEnable()
    {
        _grassGrowth.Increased += OnIncreased;
    }

    private void OnDisable()
    {
        _grassGrowth.Increased -= OnIncreased;
    }
    
    public void Collect()
    {
        _grassGrowth.enabled = true;
        _canCollect = false;
        _grassTrigger.gameObject.SetActive(false);
        Instantiate(_hay, transform.position, _hay.transform.rotation);
    }

    private void OnIncreased()
    {
        _canCollect = true;
        _grassTrigger.gameObject.SetActive(true);
    }
}
