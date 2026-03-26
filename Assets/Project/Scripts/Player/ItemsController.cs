using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private int _coinsAmount=0;
    [SerializeField] private int _timeCoins=0;

    public int TimeCoins => _timeCoins;
    public int Coins => _coinsAmount;

    public void AddCoins(int amount)
    {
        _coinsAmount += amount;
    }

    public void AddTimeCoins(int amount)
    {
        _timeCoins += amount;
    }
}
