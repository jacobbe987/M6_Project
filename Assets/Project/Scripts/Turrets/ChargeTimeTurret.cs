using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTimeTurret : Turrets
{
    [SerializeField] private float _chargetime;
    [SerializeField] private float _timerToShoot;

    private bool _isShooting= false;
    protected override void Shoot()
    {
        Instantiate(_bulletPrefab,_firePoint.position, _firePoint.rotation);

        Debug.Log("sparato");
        
    }

    protected override void Update()
    {
        
        CheckPlayer();
        
        if (_isPlayerInRange)
        {
            AimAtPlayer();
            if (!_isShooting)
            {
                StartCoroutine(ShootRoutine());
            }
            //_timerToShoot += Time.deltaTime;
            //if (_timerToShoot >= _chargetime)
            //{
            //    Shoot();
            //    _timerToShoot = 0;
            //}
            
        }
    }

    private IEnumerator ShootRoutine()
    {
        _isShooting=true;
        yield return new WaitForSeconds(_chargetime);
        Shoot();
        _isShooting = false;
    }
}
