using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement = null;
    [SerializeField] private EnemySizeArea _sizeArea = null;
    [SerializeField] private EnemyHealth _health = null;

    public Vector3 ApproximatePosition => GenerateApproximatePosition();

    public event Action<Enemy> Dead;

    private void Awake()
    {
        var rigidbody = GetComponent<Rigidbody>();
        _movement.Init(rigidbody);
        _sizeArea.Init(rigidbody);
    }

    private void OnEnable()
    {
        _health.Dead += OnDead;
        _movement.Reached += OnDead;
    }

    private void OnDisable()
    {
        _health.Dead -= OnDead;
        _movement.Reached -= OnDead;
    }

    private void OnDead()
    {
        Dead?.Invoke(this);
    }

    private Vector3 GenerateApproximatePosition()
    {
        var position = _movement.Position;
        position.x -= UnityEngine.Random.Range(0, 3f);
        return position;
    }
}


