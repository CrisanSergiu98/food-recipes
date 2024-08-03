namespace FoodRecipes.Domain.Common.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    // Protected Constructor - only derived members can construct instances of the class (and derived instances) using that constructor.
    protected Entity(Guid id)
    {
        Id = id;
    }

    // Since this is the primary identifier and it does not change we are using "init" so the value set once when the object is initialized.
    public Guid Id { get; private init; }

    // Overriding the Object Equals method
    public override bool Equals(object? obj)
    {
        // -the object cannot be null, has to be the same Type and to be an Entity
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

        // Two Entities are considered equal if they have the same ID.
        return entity.Id == Id;
    }

    // Inhereted from IEquatable
    public bool Equals(Entity? other)
    {
        // - the other entity cannot be null and has to have the same type.
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        // Two Entities are equal if they have the same ID
        return other.Id == Id;
    }

    // Mostly exists for one purpose, to serve as a hash function when the object is used as a key in a hash table.
    // HashTable example: Dictionary<TKey, TValue> is the most commonly used hash table implementation.
    public override int GetHashCode()
    {
        return Id.GetHashCode() * 41;
    }

    // Overloading the "==" opperator.
    public static bool operator ==(Entity? first, Entity? second)
    {
        // The entities can't be null and they have to be equal for this to return "true"
        return first is not null && second is not null && first.Equals(second);
    }

    // Overloading the "!=" opperator
    public static bool operator !=(Entity? first, Entity? second)
    {
        // The entities can't be null and they have to be equal for this to return "false"
        return first is not null && second is not null && !first.Equals(second);
    }
}
