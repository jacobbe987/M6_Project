using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Image _fillableLifebar;

    public void DisplayCoin(int coin)
    {
        _coinText.text = $"Coin: {coin.ToString()}/5";
    }
    public void DisplayLife(float percentageLife)
    {
        _fillableLifebar.fillAmount = Mathf.Clamp01(percentageLife);
    }

    public void DisplayTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        _timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
