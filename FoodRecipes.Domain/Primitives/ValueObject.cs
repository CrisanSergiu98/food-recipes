﻿namespace FoodRecipes.Domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject a, ValueObject b)
    {
        if (a is null && b is null) return true;

        if (a is null || b is null) return false;

        return a.Equals(b);
    }
    public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);

    public abstract IEnumerable<object> GetAtomicValues();
    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEqual(other);
    }
    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues()
            .SequenceEqual(other.GetAtomicValues());
    }
    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
}
