using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _startHealth = 100f;

    public float Value { get; private set; }

    public bool IsAlive => Value > 0;
    public bool IsDead => IsAlive == false;

    public event Action ValueChanged;
    public event Action Dead;

    protected virtual void Awake()
    {
        Value = _startHealth;
        ValueChanged?.Invoke();
    }

    public void TakeDamage(Damage damage)
    {
        if (IsDead)
            throw new InvalidOperationException(nameof(TakeDamage));

        if (damage == null)
            throw new ArgumentNullException(nameof(damage));

        Value = Math.Max(Value - damage.Value, 0);
        ValueChanged?.Invoke();

        if (IsDead)
            Dead?.Invoke();
    }
}


