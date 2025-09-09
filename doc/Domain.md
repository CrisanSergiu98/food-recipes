# Domain

## Overview

The Domain layer is the core of the Food Recipes API, encapsulating the business logic and rules. It is designed following the principles of Domain Driven Design (DDD) to ensure a robust and scalable architecture.

## Key Concepts

### Entities

Entities represent the core objects within the domain. Each entity has a unique identifier and encapsulates the business rules and logic.
```csharp
namespace FoodRecipes.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {    
        protected Entity(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; private init; }
        
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
        
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }
        
        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }
        
        public static bool operator !=(Entity? first, Entity? second)
        {
            return first is not null && second is not null && !first.Equals(second);
        }
    }
}

```

### Value Objects

Value objects are immutable and represent a descriptive aspect of the domain with no identity.

```csharp
namespace FoodRecipes.Domain.Primitives
{
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
}

```

### Aggregates

Aggregates are clusters of entities and value objects that are treated as a single unit.

```csharp
namespace FoodRecipes.Domain.Primitives
{   
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
```

### Repositories

Repositories provide an abstraction for data access, allowing the domain to remain independent of the data storage technology.

- **IRecipeRepository**: Interface for accessing and managing recipes.
```csharp
using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken = default);

    Task<List<Recipe>> GetAll(CancellationToken cancellationToken = default);

    Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken);

    Task<bool> TitleExists(string title, CancellationToken cancellationToken);

    void Update(Recipe recipe);

    void Delete(Recipe recipe);

    void Insert(Recipe recipe);
}

```
- **IIngredientRepository**: Interface for accessing and managing ingredients.
```csharp
using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IIngredientRepository : IRepository<Ingredient>
{
    Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken);

    Task<List<Ingredient>> GetAll(CancellationToken cancellationToken);

    Task<List<Ingredient>> SearchByName(string name, CancellationToken cancellationToken);

    Task<bool> NameExists(string name, CancellationToken cancellationToken);

    void Delete(Ingredient ingredient);

    void Insert(Ingredient ingredient);

    void Update(Ingredient ingredient);
}
```

## Conclusion

The Domain layer is the heart of the Food Recipes API, ensuring that business rules and logic are consistently applied. By adhering to DDD principles, the domain remains clean, maintainable, and scalable.
