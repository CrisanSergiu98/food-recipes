using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging
{
    /// <summary>
    /// Defines a handler for a query in the CQRS (Command Query Responsibility Segregation) pattern.
    /// This handler processes queries and returns a response.
    /// </summary>
    /// <typeparam name="TQuery">The type of query to be handled. Must implement <see cref="IQuery{TResponse}"/>.</typeparam>
    /// <typeparam name="TResponse">The type of response returned by the query handler.</typeparam>
    public interface IQueryHandler<in TQuery, TResponse>: IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        /// <summary>
        /// Handles the specified query asynchronously and returns a response.
        /// </summary>
        /// <param name="query">The query to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Result{TResponse}"/> indicating the outcome of the query handling along with the response.</returns>
        
        //Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
