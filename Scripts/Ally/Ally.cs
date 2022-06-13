using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ally : MonoBehaviour
{
    [SerializeField] private AllyMovement _movement = null;
    [SerializeField] private AllyProduct _product = null;
    [SerializeField] private AllyPlacePhysics _placePhysics = null;
    [SerializeField] private AllyWeapon _weapon = null;
    [SerializeField] private AllyView _view = null;

    public IAllyObstacle Obstacle => _placePhysics.Obstacle;

    public float PurchasePrice => _product.PurchasePrice;

    public Vector3 Position => _movement.Position;

    public bool IsPlaced => _placePhysics.IsPlaced;
    public bool IsNotPlaced => _placePhysics.IsPlaced == false;

    private bool _isActive;
    private bool _isPreviewActive;

    public event Action Placed
    {
        add => _placePhysics.Placed += value;
        remove => _placePhysics.Placed -= value;
    }

    public event Action FailPlaced
    {
        add => _placePhysics.FailPlaced += value;
        remove => _placePhysics.FailPlaced -= value;
    }

    protected virtual void Awake()
    { 
        var rigidbody = GetComponent<Rigidbody>();
        _movement.Init(rigidbody);
    }

    public void Active()
    {
        if (_isPreviewActive == false)
            ActivePreview();

        if (_isActive)
            throw new InvalidOperationException(nameof(Active));

        _isActive = true;
        _weapon.Active();
    }

    public void ActivePreview()
    {
        if (_isPreviewActive)
            throw new InvalidOperationException(nameof(ActivePreview));

        _isPreviewActive = true;
        _view.Active();
    }

    public void Exclude(IAllyObstacle foundation)
    {
        _placePhysics.Exclude(foundation);
    }

    public void Move(Vector3 position)
    {
        if (_placePhysics.IsStartingPlace)
            throw new InvalidOperationException(nameof(Move));

        _movement.Move(position);
    }

    public void StartPlace()
    {
        if (_placePhysics.IsStartingPlace)
            throw new InvalidOperationException(nameof(StartPlace));

        _placePhysics.StartPlace();
    }
}


