# Food Recipe API

This demo focuses on applying Domain Driven Design and Clean Architecture principles. It uses in-memory data and skips real data access and authentication/authorization features because it’s intended as a portfolio example rather than a production-ready system. It’s a practical reference for understanding how to build a well-structured and maintainable API.

# Domain Model Documentation

## Recipe Aggregate

The `Recipe` aggregate represents a recipe with a title, description, and collections of ingredients and steps.

### Properties

- **Title** (`RecipeTitle`): The title of the recipe.
- **Description** (`RecipeDescription`): The description of the recipe.
- **RecipeIngredients** (`_recipeIngredients`): Readonly collection of RecipeIngredient value objects.
- **RecipeSteps** (`_recipeSteps`): Readonly collection of RecipeStep value objects.

```json
{
  "Id": "b84e31e2-9f56-4a3e-9c72-bd792476438f",
  "Title": "Spaghetti Carbonara",
  "Description": "A classic Italian pasta dish made with eggs, cheese, pancetta, and pepper.",
  "Ingredients": [
    {
      "IngredientId": "a2b95a44-fb6b-4d42-b2a4-5b624e53b2e1",
      "Quantity": 100.0,
      "Measurement": "grams"
    },
    {
      "IngredientId": "b3a07d4c-2c60-4b5b-b9a5-d2b15f6bb9c2",
      "Quantity": 200.0,
      "Measurement": "grams"
    }
  ],
  "Steps": [
    {
      "Number": 1,
      "Description": "Cook the spaghetti according to package instructions."
    },
    {
      "Number": 2,
      "Description": "In a separate pan, cook the pancetta until crispy."
    }
  ]
}
```

---

## Ingredient Aggregate

The `Ingredient` aggregate represents an ingredient with a name and description.

### Properties

- **Name** (`IngredientName`): The name of the ingredient.
- **Description** (`IngredientDescription`): A description of the ingredient.

```json
{
  "Id": "b84e31e2-9f56-4a3e-9c72-bd792476438f",
  "Name": "Olive Oil",
  "Description": "A high-quality extra virgin olive oil."
}
```

---

## RecipeIngredient Value Object

The `RecipeIngredient` value object represents an ingredient used in a recipe, including its ID, quantity, and measurement.

### Properties

- **IngredientId** (`Guid`): Unique identifier for the ingredient.
- **Quantity** (`float`): Amount of the ingredient.
- **Measurement** (`Measurement`): The unit of measurement for the quantity.

```json
{
  "IngredientId": "a2b95a44-fb6b-4d42-b2a4-5b624e53b2e1",
  "Quantity": 100.0,
  "Measurement": "grams"
}
```

---

## RecipeStep Value Object

The `RecipeStep` value object represents a step in the recipe, including its step number and description.

### Properties

- **Number** (`int`): The step number in the recipe.
- **Description** (`RecipeStepDescription`): Description of the step.

```json
{
  "Number": 1,
  "Description": "Cook the spaghetti according to package instructions."
}

```
