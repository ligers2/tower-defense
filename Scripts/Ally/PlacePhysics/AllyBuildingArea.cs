using System;
using System.Collections.Generic;
using UnityEngine;

public class AllyBuildingArea : MonoBehaviour, ISourceTarget, IAllyObstacle
{
    public bool IsEmptyCross => _obstacles.Count == 0;

    private List<IAllyObstacle> _obstacles;
    private List<IAllyObstacle> _excluded;

    private void Awake()
    {
        _obstacles = new();
        _excluded = new();
    }

    public void Enter(Source source)
    {
        var obstacle = source.GetComponent<IAllyObstacle>();
        if (obstacle != null && _excluded.Contains(obstacle) == false)
            _obstacles.Add(obstacle);
    }

    public void Exit(Source source)
    {
        var obstacle = source.GetComponent<IAllyObstacle>();
        if (obstacle != null)
            _obstacles.Remove(obstacle);
    }

    public void Exclude(IAllyObstacle obstacle)
    {
        if (obstacle == null)
            throw new ArgumentNullException(nameof(obstacle));

        if (_excluded.Contains(obstacle))
            throw new InvalidOperationException(nameof(Exclude));

        _excluded.Add(obstacle);

        if (_obstacles.Contains(obstacle))
            _obstacles.Remove(obstacle);
    }
}


