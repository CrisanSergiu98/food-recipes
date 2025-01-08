# Application Layer

## Table of Contents
- [Overview](#overview)
- [CQRS](#cqrs)
- [Recipe Commands](#recipe-commands)
  - [Create Recipe Command](#create-recipe-command)
  - [Update Recipe Command](#update-recipe-command)
  - [Delete Recipe Command](#delete-recipe-command)
- [Recipe Queries](#recipe-queries)
  - [Get All Recipes Query](#get-all-recipes-query)
  - [Get All Units Query](#get-all-units-query)
  - [Get Recipe by ID Query](#get-recipe-by-id-query)
  - [Search Recipes by Title Query](#search-recipes-by-title-query)
- [Ingredient Commands](#ingredient-commands)
  - [Create Ingredient Command](#create-ingredient-command)
  - [Update Ingredient Command](#update-ingredient-command)
  - [Delete Ingredient Command](#delete-ingredient-command)
- [Ingredient Queries](#ingredient-queries)
  - [Get All Ingredients Query](#get-all-ingredients-query)
  - [Get Ingredient Query](#get-ingredient-query)
  - [Search Ingredient by Name Query](#search-ingredient-by-name-query)

## Overview
The Application layer handles the application logic and use cases. It acts as a mediator between the domain and presentation layers, ensuring that business rules are applied correctly. This layer is responsible for processing commands and queries, coordinating the flow of data, and managing transactions.

## CQRS

### Messaging Abstractions
```csharp
using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging;

// Defines a command in the CQRS pattern.
// A command represents an operation that changes the state of the application.
// This interface is for commands that do not return any response.
public interface ICommand : IBaseCommand, IRequest
{
}

// Defines a command in the CQRS pattern.
// A command represents an operation that changes the state of the application.
// This interface is for commands that return a response of type TResponse.
public interface ICommand<TResponse> : IBaseCommand, IRequest<TResponse>
{
}

// Base interface for all command interfaces in the CQRS pattern.
// All specific command interfaces should inherit from this interface.
// This can be used to enforce a common type or to group all command types together.
public interface IBaseCommand
{
}

```
```csharp
using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging;

// Handles commands that don't return a response.
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
    // Handles the command asynchronously.
    // Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}

// Handles commands that return a response.
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    // Handles the command asynchronously and returns a response.
    // Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}

```
```csharp
using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging;

// A query retrieves data without modifying the application's state.
public interface IQuery<TResponse> : IRequest<TResponse>
{
}

```
```csharp
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

```



## Recipe Commands

### Create Recipe Command
- **Purpose**: Handles the creation of a new recipe.
- **Command**: 
```csharp
public record CreateRecipeCommand(
    string Title, 
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps
    ):ICommand<Result<Guid>>;
```

### Update Recipe Command
- **Purpose**: Handles the update of an existing recipe.
- **Command**: 
```csharp
public record UpdateRecipeCommand(
    Guid Id,
    string Title,
    string Description,
    HashSet<RecipeIngredientDto> Ingredients,
    HashSet<string> Steps
    ) : ICommand<Result>;
```

### Delete Recipe Command
- **Purpose**: Handles the deletion of a recipe.
- **Command**: 
```csharp
public record DeleteRecipeCommand(Guid Id):ICommand<Result>;
```

## Recipe Queries

### Get All Recipes Query
- **Purpose**: Retrieves a list of all recipes.
- **Query**:
```csharp
public record GetAllRecipesQuery():IQuery<Result<List<Recipe>>>;
```

### Get All Units Query
- **Purpose**: Retrieves a list of all units.
- **Query**: 
```csharp
public record GetAllUnitsQuery() : IQuery<Result<string[]>>;
```

### Get Recipe by ID Query
- **Purpose**: Retrieves a recipe by its ID.
- **Query**: 
```csharp
public record GetRecipeByIdQuery(Guid Id):IQuery<Result<Recipe>>;
```

### Search Recipes by Title Query
- **Purpose**: Searches for recipes by title.
- **Query**: 
```csharp
public record SearchRecipesByTitleQuery(string Title):IQuery<Result<IEnumerable<Recipe>>>;
```

## Ingredient Commands

### Create Ingredient Command
- **Purpose**: Handles the creation of a new ingredient.
- **Command**:
```csharp
public record CreateIngredientCommand(
    string Name,
    string Description
    ):ICommand<Result<Guid>>;
```

### Update Ingredient Command
- **Purpose**: Handles the update of an existing ingredient.
- **Command**:
```csharp
public record UpdateIngredientCommand(
    Guid Id,
    string Name,
    string Description
    ) : ICommand<Result>;
```

### Delete Ingredient Command
- **Purpose**: Handles the deletion of an ingredient.
- **Command**:
```csharp
public record DeleteIngredientCommand(Guid Id):ICommand<Result>;
```

## Ingredient Queries

### Get All Ingredients Query
- **Purpose**: Retrieves a list of all ingredients.
- **Query**:
```csharp
public record GetAllIngredientsQuery(): IQuery<Result<List<Ingredient>>>;
```

### Get Ingredient Query
- **Purpose**: Retrieves an ingredient by its ID.
- **Query**:
```csharp
public record GetIngredientQuery(Guid IngredientId) : IQuery<Result<Ingredient>>;
```

### Search Ingredient by Name Query
- **Purpose**: Searches for ingredients by name.
- **Query**:
```csharp
public record SearchIngredientsByNameQuery(
    string Name
    ):IQuery<Result<IEnumerable<Ingredient>>>;
```
