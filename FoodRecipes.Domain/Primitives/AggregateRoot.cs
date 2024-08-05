namespace FoodRecipes.Domain.Primitives
{
    /// <summary>
    /// Represents a base class for aggregate roots, which are entities that serve as the root for an aggregate in the domain model.
    /// </summary>
    public abstract class AggregateRoot : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class with a specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the aggregate root.</param>
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
