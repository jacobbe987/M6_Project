using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Traps
{
    private Animator _animator;

    [SerializeField] private int _dmg;
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

        _lifeController.RemoveHp(_dmg);

        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            _isActive = true;
            _timer= 0;
        }
    }
}
