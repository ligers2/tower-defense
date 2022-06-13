using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    public Vector3 Position => _rigidbody.position;

    public event Action Reached;

    private Rigidbody _rigidbody;

    public void Init(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    private void FixedUpdate()
    {
        var offset = Vector3.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offset);
        if (_rigidbody.position.x >= 10)
            Reached?.Invoke();
    }
}


