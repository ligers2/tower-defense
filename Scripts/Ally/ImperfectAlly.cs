using System;
using UnityEngine;

public class ImperfectAlly : Ally
{
    [SerializeField] private Ally _upgrade = null;

    public event Action<ImperfectAlly, Ally> WishedUpgrade;
    public event Action<ImperfectAlly, Ally> Upgrade;
    public event Action<ImperfectAlly, Ally> FailUpgrade;

    private bool IsNotUpgrading => _isUpgrading == false;

    private Ally _toSuspect;
    private bool _isUpgrading;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && IsPlaced && IsNotUpgrading)
            WishUpgrade();
    }

    private void WishUpgrade()
    {
        if (IsNotPlaced || _isUpgrading)
            throw new InvalidOperationException(nameof(WishUpgrade));

        _isUpgrading = true;
        WishedUpgrade?.Invoke(this, _upgrade);
    }

    public void StartUpgrage(Ally toSuspect)
    {
        if (toSuspect == null)
            throw new ArgumentNullException(nameof(toSuspect));

        if (IsNotUpgrading)
            throw new InvalidOperationException(nameof(StartUpgrage));

        _toSuspect = toSuspect;

        toSuspect.Placed += Success;
        toSuspect.FailPlaced += Fail;

        toSuspect.Exclude(Obstacle);
        toSuspect.Move(Position);
        toSuspect.StartPlace();
    }

    private void Success()
    {
        EndUpgrade();
        Upgrade?.Invoke(this, _toSuspect);
    }

    private void Fail()
    {
        EndUpgrade();
        FailUpgrade?.Invoke(this, _toSuspect);
    }

    private void EndUpgrade()
    {
        if (_toSuspect == null)
            throw new InvalidOperationException(nameof(EndUpgrade));

        if (_isUpgrading == false)
            throw new InvalidOperationException(nameof(EndUpgrade));

        _isUpgrading = false;
        _toSuspect.Placed -= Success;
        _toSuspect.FailPlaced -= Fail;
    }
}
