using System;

public class Damage
{
    public float Value { get; }

    public Damage(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value = value;
    }
}


