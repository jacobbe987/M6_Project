using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemsController _itemsController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private LifeController _lifecontroller;

    [SerializeField] private Canvas _canvasGameOver;
    [SerializeField] private Canvas _canvasGameFinished;

    [SerializeField] private UnityEvent<float> _onChangeCountdown;

    [SerializeField] private float _countdown;

    public float Countdown=>_countdown;
    public LifeController LifeController => _lifecontroller;
    private void Awake()
    {
        GameResumed();
    }
    private void Update()
    {
        if (_countdown <= 1 || _lifecontroller.Hp<=0)
        {
            GameOver();
        }
        if (_itemsController.Coins >= 100)
        {
            GameFinished();
        }
        _countdown -= Time.deltaTime;
        _onChangeCountdown.Invoke(_countdown);
    }
    public void GameOver()
    {
        _canvasGameOver.gameObject.SetActive(true);
        GamePaused();
    }

    public void GameFinished()
    {
        _canvasGameFinished.gameObject.SetActive(true);
        GamePaused();
    }

    public void GamePaused()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _cameraController.enabled = false;
    }

    public void GameResumed()
    {
        Time.timeScale = 1;
        _cameraController.enabled = true;
    }

    public void AddTime(float timeCoinValue)
    {
        float timeToAdd = _itemsController.TimeCoins * timeCoinValue;
        _countdown += timeToAdd;
    }
}
