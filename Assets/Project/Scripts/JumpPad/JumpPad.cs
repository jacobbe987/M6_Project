using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _padForce;
    private bool _isPlayer;
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private Transform _jumpPad;
    [SerializeField] private float _padSphere = 3f;
    [SerializeField] private LayerMask _playerMask;

    

    private void Update()
    {
        PlayerCheck();
        PadActive();
    }
    private void PlayerCheck()
    {
        _isPlayer = Physics.CheckSphere(_jumpPad.position, _padSphere, _playerMask);
    }

    private void PadActive()
    {
        if (_isPlayer)
        {
            _playerRb.AddForce(Vector3.up * _padForce, ForceMode.Impulse);
        }
    }
}
