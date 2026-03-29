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
        SoundFxManager._instance.PlayFxSound("CannonShot");
        Bullets bulletObj = _objPool.Get();
        bulletObj.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bulletObj.BulletPhysic();
        bulletObj.Deactive();
        
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
