using System;
using UnityEngine;

public abstract class Wallet : MonoBehaviour
{
    [SerializeField] private float _startMoney = 30f;

    public float Money { get; private set; }

    public event Action MoneyChanged;

    protected virtual void Awake()
    {
        Money = _startMoney;
        MoneyChanged?.Invoke();
    }

    public void Earn(Salary salary)
    {
        if (salary == null)
            throw new ArgumentNullException(nameof(salary));

        Money += salary.Value;
        MoneyChanged?.Invoke();
    }

    public bool CanSpend(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        return Money >= value;
    }

    public void Spend(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (CanSpend(value) == false)
            throw new InvalidOperationException(nameof(Spend));

        Money -= value;
        MoneyChanged?.Invoke();
    }
}


