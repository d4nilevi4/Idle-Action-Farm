using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    [SerializeField] private Slicer _slicer;
    private void OnTriggerEnter(Collider other)
    {
        _slicer.isTouched = true;
    }
}
