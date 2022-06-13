using System;
using UnityEngine;

public class AllyShop : MonoBehaviour
{
    [SerializeField] private AllyParent _parent = null;
    [SerializeField] private AllyUpgradeShop _upgradeShop = null;

    public bool HasSpawned => _preview != null;
    public bool HasNotSpawned => HasSpawned == false;

    public bool IsPlaceStarted => _isPlaceStarted;
    public bool IsPlaceNotStarted => IsPlaceStarted == false;

    private Ally _preview;
    private bool _isPlaceStarted;

    public void StartPlace()
    {
        if (HasNotSpawned)
            throw new InvalidOperationException(nameof(StartPlace));

        if (IsPlaceStarted)
            throw new InvalidOperationException(nameof(StartPlace));

        _isPlaceStarted = true;
        _preview.Placed += OnPlaced;
        _preview.FailPlaced += OnFailPlaced;
        _preview.StartPlace();
    }

    public void Spawn(Ally ally, Vector3 position)
    {
        if (ally == null)
            throw new ArgumentNullException(nameof(ally));

        if (HasSpawned)
            throw new InvalidOperationException(nameof(Spawn));

        _preview = _parent.Get(ally, position);
        _preview.ActivePreview();
    }

    public void MovePreview(Vector3 position)
    {
        if (HasNotSpawned)
            throw new InvalidOperationException(nameof(MovePreview));

        if (IsPlaceStarted)
            throw new InvalidOperationException(nameof(MovePreview));

        _preview.Move(position);
    }

    private void OnPlaced()
    {
        if (IsPlaceNotStarted)
            throw new InvalidOperationException(nameof(OnPlaced));

        _isPlaceStarted = false;
        _preview.Placed -= OnPlaced;
        _preview.Placed -= OnFailPlaced;
        _preview.Active();
        _upgradeShop.StartListen(_preview);
        _preview = null;
    }

    private void OnFailPlaced()
    {
        _isPlaceStarted = false;
        _preview.Placed -= OnPlaced;
        _preview.Placed -= OnFailPlaced;
    }
}
