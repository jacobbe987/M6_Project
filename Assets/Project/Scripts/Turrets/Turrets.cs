using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Turrets : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected Bullets _bulletPrefab;
    [SerializeField] protected Transform _target;

    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _timer;

    [SerializeField] protected bool _isPlayerInRange;
    [SerializeField] protected float _checkPlayerInRange = 5f;
    [SerializeField] protected LayerMask _playerMask;

    protected IObjectPool<Bullets> _objPool;
    protected bool _isCollected;
    protected int _poolCapacity = 10;
    protected int _poolMaxSize = 50;


    protected void Awake()
    {
        _objPool = new ObjectPool<Bullets>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, _isCollected, _poolCapacity, _poolMaxSize);
    }

    protected Bullets CreateBullet()
    {
        Bullets objBullet = Instantiate(_bulletPrefab);
        objBullet.gameObject.SetActive(false);
        objBullet.transform.SetParent(this.transform);
        objBullet.SetObjPool(_objPool);
        return objBullet;
    }

    protected void OnGetBullet(Bullets pooledBullet)
    {
        pooledBullet.gameObject.SetActive(true);
    }

    protected void OnReleaseBullet(Bullets pooledBullet)
    {
        pooledBullet.gameObject.SetActive(false);
    }

    protected void OnDestroyBullet(Bullets pooledBullet)
    {
        Destroy(pooledBullet.gameObject);
    }

    protected void AimAtPlayer()
    {
        Vector3 _direction = _target.position - transform.position;
        //_firePoint.forward = transform.forward;
        transform.forward = _direction;
    }

    protected void CheckPlayer()
    {
        _isPlayerInRange = Physics.CheckSphere(transform.position, _checkPlayerInRange, _playerMask);
    }

    protected abstract void Shoot();

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
