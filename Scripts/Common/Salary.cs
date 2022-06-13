using System;

public class Salary
{
    public float Value { get; }

    public Salary(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value = value;
    }
}


