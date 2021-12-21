using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _coinsForDestroy = 5;

    public event Action<int> DestroyedByPlayer; 
    public event Action<int> OnReachingEnd; 
    
    public void Deactivate()
    {
        gameObject.SetActive(false);
        DestroyedByPlayer = null;
        OnReachingEnd = null;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isOtherIsLoseBorder = other.gameObject.TryGetComponent(out LoseBorder component);
        if (isOtherIsLoseBorder)
        {
            OnReachingEnd?.Invoke(_damage);
            Deactivate();
        }
    }

    private void OnMouseDown()
    {
        DestroyByPlayer();
    }

    private void DestroyByPlayer()
    {
        DestroyedByPlayer?.Invoke(_coinsForDestroy);
        Deactivate();
    }
}