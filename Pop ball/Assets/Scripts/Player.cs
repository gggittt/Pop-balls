using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private int _startHeath = 5;
    private int _currentHeath;
    private int _coins;


    public event Action Died;
    public event Action<int> OnHealthChanged;
    public event Action<int> OnCoinsChanged;

    private void Start()
    {
        ResetStats();
    }

    public bool HasCoinsForPurchase(int purchaseCost) => purchaseCost >= _coins;

    public void ApplyDamage(int amount)
    {
        _currentHeath -= amount;
        OnHealthChanged?.Invoke(_currentHeath);

        if (_currentHeath <= 0)
        {
            Died?.Invoke();
        }
    }

    public void ChangeCoinsAmount(int amount)
    {
        _coins += amount;
        OnCoinsChanged?.Invoke(_coins);
    }
    
    public void ResetStats()
    {
        _coins = 0;
        _currentHeath = _startHeath;
        OnCoinsChanged?.Invoke(_coins);
        OnHealthChanged?.Invoke(_currentHeath);
    }
}