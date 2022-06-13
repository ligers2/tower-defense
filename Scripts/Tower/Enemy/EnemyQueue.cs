using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueue : MonoBehaviour
{
    [SerializeField] private float _secondsDelay = 0.2f;
    [SerializeField] private Vector3 _position = Vector3.zero;

    [SerializeField] private EnemyParent _parent = null;

    private Queue<Enemy> _futureChildren;
    private float _expiredSeconds;

    private void Awake()
    {
        _futureChildren = new();
    }

    private void Update()
    {
        _expiredSeconds += Time.deltaTime;
        if (_expiredSeconds >= _secondsDelay && _futureChildren.Count > 0)
        {
            _expiredSeconds = 0;
            _parent.Get(_futureChildren.Dequeue(), _position);
        }
    }

    public void Put(IReadOnlyList<Enemy> futureChildren)
    {
        if (futureChildren == null)
            throw new InvalidOperationException(nameof(Put));

        foreach (var futureChild in futureChildren)
            _futureChildren.Enqueue(futureChild);
    }
}
