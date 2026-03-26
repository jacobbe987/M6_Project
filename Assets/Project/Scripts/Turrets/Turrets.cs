using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _target;

    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _timer;

    [SerializeField] protected bool _isPlayerInRange;
    [SerializeField] protected float _checkPlayerInRange = 5f;
    [SerializeField] protected LayerMask _playerMask;

    protected void AimAtPlayer()
    {
        Vector3 _direction = _target.position - transform.position;
        _firePoint.forward = transform.forward;
        transform.forward = _direction;
    }

    protected void CheckPlayer()
    {
        _isPlayerInRange = Physics.CheckSphere(transform.position, _checkPlayerInRange, _playerMask);
    }

    protected virtual void Shoot()
    {

    }

    protected virtual void Update()
    {
        CheckPlayer();

        if( _isPlayerInRange)
        {
            AimAtPlayer();
            _timer += Time.deltaTime;
            if (_timer>= 1 / _fireRate)
            {
                Shoot();
                _timer = 0;
            }
        }
    }

}
