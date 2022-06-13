using System;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class AllyWeapon : MonoBehaviour
{
    [SerializeField] private float _secondsDelay = 1f;

    [SerializeField] private AllyDetectArea _area = null;
    [SerializeField] private AllyBullet _bullet = null;

    public event Action<AllyBullet, Vector3, Vector3> WishedFire;

    private float _expiredSeconds;
    private bool _active;

    private void Update()
    {
        if (_active == false)
            return;

        _expiredSeconds += Time.deltaTime;
        if (_expiredSeconds >= _secondsDelay && _area.NotEmpty)
        {
            _expiredSeconds = 0;
            WishedFire?.Invoke(_bullet, transform.position, _area.First().Position);
        }
    }

    public void Active()
    {
        if (_active)
            throw new InvalidOperationException(nameof(Active));

        _active = true;
    }
}


