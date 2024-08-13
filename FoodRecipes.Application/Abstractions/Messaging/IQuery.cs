using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging
{
    /// <summary>
    /// Represents a query in the CQRS (Command Query Responsibility Segregation) pattern.
    /// A query retrieves data from the application without modifying its state.
    /// </summary>
    /// <typeparam name="TResponse">The type of response returned by the query.</typeparam>
    public interface IQuery<TResponse>:IRequest<TResponse>
    {
    }
}
