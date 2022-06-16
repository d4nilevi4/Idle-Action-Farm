using UnityEngine;
using UnityEngine.Events;

public class GrassGrowth : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private float _growthTimeInSeconds = 10f;

    [SerializeField] private Vector3 _maxScale;

    private Material _material;
    private Vector3 _currentScale;
    private float _currentTime = 0f;

    public event UnityAction Increased;

    private void OnEnable()
    {
        _currentTime = 0;
        _currentScale = Vector3.zero;
        _material = GetComponent<MeshRenderer>().material;
        _material.color = _gradient.Evaluate(0);
    }

    private void Update()
    {
        if (_currentTime >= _growthTimeInSeconds)
        {
            Increased?.Invoke();
            enabled = false;
        }

        _currentScale = (_currentTime / _growthTimeInSeconds) * _maxScale;

        _currentTime += Time.deltaTime;
        _material.color = _gradient.Evaluate(_currentTime / _growthTimeInSeconds);
        transform.localScale = _currentScale;
    }
}
