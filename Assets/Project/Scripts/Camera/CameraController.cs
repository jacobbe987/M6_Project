using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _offset;
    [SerializeField] private float _sens;
    [SerializeField] private float _minY, _maxY;
    [SerializeField] private Image _crossHair;
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

        Quaternion _rotation = Quaternion.Euler(_rotationY,_rotationX,0);

        Vector3 _position = _player.position - _rotation * Vector3.forward * _offset;

        transform.position = _position;
        transform.rotation = _rotation;
    }

    [ContextMenu("1st person")]
    public void FirstPerson()
    {
        _offset=0f;
        _crossHair.enabled = true;
    }

    [ContextMenu("3rd person")]
    public void ThirdPerson()
    {
        _offset=7f;
        _crossHair.enabled = false;
    }
}
