using System;
using UnityEngine;

public class AllyBulletParent : MonoBehaviour
{
    public void Create(AllyBullet prefab, Vector3 position, Vector3 direction)
    {
        if (prefab == null)
            throw new ArgumentNullException(nameof(prefab));

        var bullet = Instantiate(prefab, position, Quaternion.identity);
        bullet.Dead += OnDead;

        bullet.Init(direction);
    }

    private void OnDead(AllyBullet bullet)
    {
        bullet.Dead -= OnDead;
        Destroy(bullet.gameObject);
    }
}
