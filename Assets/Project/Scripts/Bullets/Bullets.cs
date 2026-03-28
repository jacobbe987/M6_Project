using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullets : MonoBehaviour
{
    private Rigidbody _rb;
    private Rigidbody _playerRb;

    [SerializeField] private int _dmg;
    [SerializeField] private float _speed;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private LayerMask _playerMask;

    private IObjectPool<Bullets> _bulletsPool;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
        Deactive();
    }

    private void Explosion()
    {
        Collider[] playerHitted = Physics.OverlapSphere(transform.position, _explosionRadius, _playerMask);
        if (playerHitted.Length > 0)
        {
            _playerRb= playerHitted[0].GetComponent<Rigidbody>();

            if(_playerRb != null)
            {
                _playerRb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                _playerRb.TryGetComponent<LifeController>(out var playerLifeController);
                playerLifeController.RemoveHp(_dmg);
            }
        }
    }

    public void SetObjPool(IObjectPool<Bullets> bulletPool)
    {
        _bulletsPool = bulletPool;
    }


    private void Deactive()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _bulletsPool.Release(this);
    }

    public void BulletPhysic()
    {
        _rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }
}
