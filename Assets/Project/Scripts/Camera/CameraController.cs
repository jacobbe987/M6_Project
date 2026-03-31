using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _offset;
    [SerializeField] private float _sens;
    [SerializeField] private float _minY, _maxY;

    private float _rotationX,_rotationY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        _rotationX += Input.GetAxis("Mouse X") * _sens;
        _rotationY -= Input.GetAxis("Mouse Y") * _sens;
        _rotationY = Mathf.Clamp(_rotationY, _minY, _maxY);
        _player.rotation = Quaternion.Euler(0f, _rotationX, 0f);
        _cameraPivot.localRotation = Quaternion.Euler(_rotationY, 0f, 0f);

    }
}
