using System.Collections;
using System;
using UnityEngine;


public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = .5f;
    private WaitForSeconds _spawnDelaySeconds;

    [SerializeField] private float _ballStartTopPosition = 1.7f;
    private float _leftBorder, _rightBorder;

    [SerializeField] private LoseBorder _loseBorder;

    [SerializeField] private Pool _pool;
    [SerializeField] private Player _player;


    private void Awake()
    {
        CalculateSpawnBorders();
        _spawnDelaySeconds = new WaitForSeconds(_spawnDelay);
        StartCoroutine(Spawn());
    }

    private void CalculateSpawnBorders()
    {
        Transform borderTransform = _loseBorder.transform;
        
        Vector3 borderPosition = borderTransform.position;
        Vector3 borderScale = borderTransform.localScale;

        _leftBorder = borderPosition.x - borderScale.x / 2;
        _rightBorder = borderPosition.x + borderScale.x / 2;
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            Ball ball = _pool.GetElement();

            ball.DestroyedByPlayer += _player.ChangeCoinsAmount;
            ball.OnReachingEnd += _player.ApplyDamage;

            ball.transform.position = GetRandomPosition();
            
            yield return _spawnDelaySeconds;
        }
    }

    private Vector3 GetRandomPosition()
    {
        var x = UnityEngine.Random.Range(_leftBorder, _rightBorder);
        return new Vector3(x, _ballStartTopPosition);
    }
}