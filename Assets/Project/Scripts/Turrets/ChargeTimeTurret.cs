using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTimeTurret : Turrets
{
    [SerializeField] private float _chargetime;
    [SerializeField] private float _timerToShoot;
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
            _timerToShoot += Time.deltaTime;
            if (_timerToShoot >= _chargetime)
            {
                Shoot();
                _timerToShoot = 0;
            }
            
        }
    }
}
