using System;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class AllyWeapon : MonoBehaviour
{
    [SerializeField] private float _secondsDelay = 1f;

    [SerializeField] private AllyDetectArea _area = null;
    [SerializeField] private AllyBullet _bullet = null;

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
            Fire();
        }
    }

    public void Active()
    {
        if (_active)
            throw new InvalidOperationException(nameof(Active));

        _active = true;
    }

    private void Fire()
    {
        var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        bullet.Init(_area.First().Position);
    }
}


