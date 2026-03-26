using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    protected bool _isActive;

    [SerializeField] protected LifeController _lifeController;
    protected virtual void TrapEffect()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !_isActive)
        {
            return;
        }

        TrapEffect();
    }
}
