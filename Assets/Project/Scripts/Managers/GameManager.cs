using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemsController _itemsController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private LifeController _lifecontroller;
    [SerializeField] private SettingsManager _settingManager;

    [SerializeField] private Canvas _canvasGameOver;
    [SerializeField] private Canvas _canvasGameFinished;
    [SerializeField] private Canvas _canvasGameOptions;
    [SerializeField] private Canvas _canvasGameStatus;

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
        if (_itemsController.Coins >= 5)
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

    public void GameOptions()
    {
        _canvasGameOptions.gameObject.SetActive(true);
        _canvasGameStatus.gameObject.SetActive(false);
        GamePaused();
    }

    public void GameResumed()
    {
        _canvasGameOptions.gameObject.SetActive(false);
        _settingManager.SaveSettings();
        _canvasGameStatus.gameObject.SetActive(true);
        Time.timeScale = 1;
        _cameraController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AddTime(float timeCoinValue)
    {
        float timeToAdd = _itemsController.TimeCoins * timeCoinValue;
        _countdown += timeToAdd;
    }
}
