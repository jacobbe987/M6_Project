using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameStatus : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Image _lifebarFillable;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void UpdateLifebar(int _hp, int _maxHp)
    {
        float _percentageLife = (float)_hp / 100;
        _lifebarFillable.fillAmount= _percentageLife;
    }

    public void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        _timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnEnable()
    {
        UpdateTimer(_gameManager.Countdown);
    }
}
