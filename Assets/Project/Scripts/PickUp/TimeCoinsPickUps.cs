using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCoinsPickUps : OnPickEffects
{
    [SerializeField] private int _timeCoin;
    [SerializeField] private float _timeCoinsValue;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public override void OnPick(GameObject player)
    {

        var _itemCollected = player.GetComponent<ItemsController>();
        if (_itemCollected != null)
        {
            _itemCollected.AddTimeCoins(_timeCoin);
            _gameManager.AddTime(_timeCoinsValue);
        }
    }
}