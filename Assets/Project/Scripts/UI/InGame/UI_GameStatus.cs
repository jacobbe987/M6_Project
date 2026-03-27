using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameStatus : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UI_LifeBar _lifeBar;
    [SerializeField] private UI_Timer _timer;

    public void UpdateLifebar(int hp, int maxHp)
    {
        float percentageLife = (float)hp / maxHp;
        _lifeBar.DisplayLife(percentageLife);
    }

    public void UpdateTimer(float time)
    {
        _timer.DisplayTimer(time);
    }

    private void OnEnable()
    {
        UpdateTimer(_gameManager.Countdown);
        UpdateLifebar(_gameManager.LifeController.Hp, _gameManager.LifeController.Maxhp);
    }
}
