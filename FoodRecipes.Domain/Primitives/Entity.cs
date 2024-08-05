namespace FoodRecipes.Domain.Primitives
{
    /// <summary>
    /// Represents a base class for entities, which have a unique identifier and can be compared based on their identity.
    /// </summary>
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class with a specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the entity.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public Guid Id { get; private init; }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Entity"/>.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="Entity"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not Entity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Entity"/> is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="other">The <see cref="Entity"/> to compare with the current <see cref="Entity"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Entity"/> is equal to the current <see cref="Entity"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }
            return other.Id == Id;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Entity"/>.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }

        /// <summary>
        /// Determines whether two <see cref="Entity"/> instances are equal.
        /// </summary>
        /// <param name="first">The first <see cref="Entity"/> instance to compare.</param>
        /// <param name="second">The second <see cref="Entity"/> instance to compare.</param>
        /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        /// <summary>
        /// Determines whether two <see cref="Entity"/> instances are not equal.
        /// </summary>
        /// <param name="first">The first <see cref="Entity"/> instance to compare.</param>
        /// <param name="second">The second <see cref="Entity"/> instance to compare.</param>
        /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Entity? first, Entity? second)
        {
            return first is not null && second is not null && !first.Equals(second);
        }
    }
}
