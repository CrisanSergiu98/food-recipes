namespace FoodRecipes.Domain.Primitives
{
    /// <summary>
    /// Represents a base class for value objects, which are immutable and can be compared based on their values.
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        /// <summary>
        /// Determines whether two <see cref="ValueObject"/> instances are equal.
        /// </summary>
        /// <param name="a">The first <see cref="ValueObject"/> instance to compare.</param>
        /// <param name="b">The second <see cref="ValueObject"/> instance to compare.</param>
        /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether two <see cref="ValueObject"/> instances are not equal.
        /// </summary>
        /// <param name="a">The first <see cref="ValueObject"/> instance to compare.</param>
        /// <param name="b">The second <see cref="ValueObject"/> instance to compare.</param>
        /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);

        /// <summary>
        /// Gets the atomic values that make up this <see cref="ValueObject"/>.
        /// </summary>
        /// <returns>An enumerable collection of the atomic values.</returns>
        public abstract IEnumerable<object> GetAtomicValues();

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="ValueObject"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="ValueObject"/>.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="ValueObject"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            return obj is ValueObject other && ValuesAreEqual(other);
        }

        /// <summary>
        /// Determines whether the atomic values of the current <see cref="ValueObject"/> are equal to the atomic values of another <see cref="ValueObject"/>.
        /// </summary>
        /// <param name="other">The other <see cref="ValueObject"/> to compare.</param>
        /// <returns><c>true</c> if the atomic values are equal; otherwise, <c>false</c>.</returns>
        private bool ValuesAreEqual(ValueObject other)
        {
            return GetAtomicValues()
                .SequenceEqual(other.GetAtomicValues());
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="ValueObject"/>.</returns>
        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Aggregate(
                    default(int),
                    HashCode.Combine);
        }

        /// <summary>
        /// Determines whether the specified <see cref="ValueObject"/> is equal to the current <see cref="ValueObject"/>.
        /// </summary>
        /// <param name="other">The <see cref="ValueObject"/> to compare with the current <see cref="ValueObject"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ValueObject"/> is equal to the current <see cref="ValueObject"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ValueObject? other)
        {
            return other is not null && ValuesAreEqual(other);
        }
    }
}
