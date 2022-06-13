using System;
using UnityEngine;

public class AllyPlacePhysics : MonoBehaviour
{
    [SerializeField] private AllyBuildingArea _buildingArea = null;

    public IAllyObstacle Obstacle => _buildingArea;
    public bool IsStartingPlace => _isStartingPlace;
    public bool IsNotStartingPlace => IsStartingPlace == false;
    public bool IsPlaced => _isPlaced;

    public event Action Placed;
    public event Action FailPlaced;
    
    private int _frame;
    private bool _isStartingPlace;
    private bool _isPlaced;

    private void FixedUpdate()
    {
        if (IsPlaced || IsNotStartingPlace)
            return;

        _frame++;

        if (_frame < 2)
            return;

        if (_buildingArea.IsEmptyCross)
        {
            _isPlaced = true;
            Placed?.Invoke();
        }
        else
        {
            FailPlaced?.Invoke();
            _isStartingPlace = false;
        }
    }

    public void StartPlace()
    {
        if (_isStartingPlace)
            throw new InvalidOperationException(nameof(StartPlace));

        _frame = 0;
        _isStartingPlace = true;
    }

    public void Exclude(IAllyObstacle obstacle)
    {
        _buildingArea.Exclude(obstacle);
    }
}
