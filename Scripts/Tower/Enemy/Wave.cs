using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    [SerializeField] private List<Enemy> _enemies = null;

    public IReadOnlyList<Enemy> Enemies => _enemies;
}
