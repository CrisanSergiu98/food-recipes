using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging
{
    // Handles queries in the CQRS pattern and returns a response.
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        // Handles the query asynchronously and returns a response.
        // Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
