using System;
using System.Collections.Generic;
using UnityEngine;

public class AllyDetectArea : MonoBehaviour, ISourceTarget
{
    public bool Empty => _discovered.Count == 0;
    public bool NotEmpty => Empty == false;

    private List<EnemySizeArea> _discovered;

    private void Awake()
    {
        _discovered = new();
    }

    public void Enter(Source source)
    {
        var enemy = source.GetComponent<EnemySizeArea>();
        if (enemy != null)
            _discovered.Add(enemy);
    }

    public void Exit(Source source)
    {
        var enemy = source.GetComponent<EnemySizeArea>();
        if (enemy != null)
            _discovered.Remove(enemy);
    }

    public EnemySizeArea First()
    {
        if (Empty)
            throw new InvalidOperationException(nameof(First));

        return _discovered[0];
    }
}


