using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTrap : Traps
{
    private Animator _animator;

    [SerializeField] private float _pushForce;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _timer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void TrapEffect()
    {
        _isActive = false;

        _animator.SetTrigger("_active");

        Rigidbody playerRb = _lifeController.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            playerRb.AddForce(transform.right * _pushForce, ForceMode.Impulse);
        }

        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            _isActive = true;
            _timer = 0;
        }
    }
}
