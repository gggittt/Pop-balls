using UnityEngine;
using UnityRandom = UnityEngine.Random;

[RequireComponent(typeof(Ball))]
public class BallMove : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1;
    [SerializeField] private float _maxSpeed = 6;

    [SerializeField] private float _speed = 3f;

    private void OnEnable()
    {
        _speed = GetRandomSpeed();
    }

    private float GetRandomSpeed() => UnityRandom.Range(_minSpeed, _maxSpeed);

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}