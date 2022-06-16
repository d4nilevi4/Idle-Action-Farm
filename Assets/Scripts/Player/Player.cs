using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private SliceListener _sickle;

    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        _animator.SetBool("isCollectGrass", false);
        _sickle.gameObject.SetActive(false);
        _playerMovement.SetRunningSpeed();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out GrassTrigger _grassTrigger))
        {
            _animator.SetBool("isCollectGrass", true);
            _sickle.gameObject.SetActive(true);
            _playerMovement.SetSpeedDuringCollection();
        } 
    }
}
