using System;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public Enemy Get(Enemy prefab, Vector3 position)
    {
        if (prefab == null)
            throw new ArgumentNullException(nameof(prefab));

        var enemy = Instantiate(prefab, position, Quaternion.identity);
        enemy.Dead += OnDead;

        return enemy;
    }

    private void OnDead(Enemy enemy)
    {
        enemy.Dead -= OnDead;

        var fat = enemy.GetComponent<FatEnemy>();
        if (fat)
            Split(fat);

        Destroy(enemy.gameObject);
    }

    private void Split(FatEnemy fat)
    {
        foreach (var enemy in fat.Parts)
            Get(enemy, fat.ApproximatePosition);
    }
}


