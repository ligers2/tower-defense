using System;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Vector3 Position => _rigidbody.position;

    private Rigidbody _rigidbody;
    private Vector3 _nextPosition;
    private Vector3 _position;

    public void Init(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
    }

    private void FixedUpdate()
    {
        if (_nextPosition == _position)
            return;

        _rigidbody.MovePosition(_nextPosition);
        _position = _nextPosition;
    }

    public void Move(Vector3 position)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));

        _nextPosition = position;
    }
}


