using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : Enemy
{
    [SerializeField] private List<Enemy> _parts;

    public IReadOnlyList<Enemy> Parts => _parts;
}
