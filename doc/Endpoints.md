# API Endpoints


## Table of Contents  
-  [Recipes](#recipes) 
	-  [Get All Recipes](#get-all-recipes) 
	-  [Get Recipe by ID](#get-recipe-by-id) 
	-  [Create Recipe](#create-recipe) 
	-  [Update Recipe](#update-recipe) 
	-  [Delete Recipe](#delete-recipe) 
	-  [Search Recipe by Title](#search-recipe-by-title) 
-  [Ingredients](#ingredients) 
	-  [Get All Ingredients](#get-all-ingredients) 
	-  [Get Ingredient by ID](#get-ingredient-by-id) 
	-  [Create Ingredient](#create-ingredient) 
	-  [Update Ingredient](#update-ingredient) 
	-  [Delete Ingredient](#delete-ingredient) 
	-  [Search Ingredient by Name](#search-ingredient-by-name)

## Recipes

### Get All Recipes
- **Endpoint**: `/api/recipes`
- **Method**: `GET`
- **Description**: Retrieves a list of all recipes.
- **Response**: [Sample Response]

### Get Recipe by ID
- **Endpoint**: `/api/recipes/{id}`
- **Method**: `GET`
- **Description**: Retrieves a recipe by its ID.
- **Response**: [Sample Response]

### Create Recipe
- **Endpoint**: `/api/recipes`
- **Method**: `POST`
- **Description**: Creates a new recipe.
- **Request Body**: 
```json
{
  "title": "Spaghetti Carbonara",
  "description": "A classic Italian pasta dish made with eggs, cheese, pancetta, and pepper.",
  "ingredients": [
    {
      "ingredientId": "a2b95a44-fb6b-4d42-b2a4-5b624e53b2e1",
      "quantity": 100.0,
      "measurement": "grams"
    }
  ],
  "steps": [
    {
      "number": 1,
      "description": "Cook the spaghetti according to package instructions."
    }
  ]
}

```
- **Response**: [Sample Response]

### Update Recipe
- **Endpoint**: `/api/recipes/{id}`
- **Method**: `PUT`
- **Description**: Updates an existing recipe.
- **Request Body**: 
```json
{
  "id": "b84e31e2-9f56-4a3e-9c72-bd792476438f",
  "title": "Spaghetti Carbonara",
  "description": "A classic Italian pasta dish made with eggs, cheese, pancetta, and pepper.",
  "ingredients": [
    {
      "ingredientId": "a2b95a44-fb6b-4d42-b2a4-5b624e53b2e1",
      "quantity": 100.0,
      "measurement": "grams"
    }
  ],
  "steps": [
    {
      "number": 1,
      "description": "Cook the spaghetti according to package instructions."
    }
  ]
}

```
- **Response**: [Sample Response]

### Delete Recipe
- **Endpoint**: `/api/recipes/{id}`
- **Method**: `DELETE`
- **Description**: Deletes a recipe by its ID.
- **Response**: [Sample Response]

### Search Recipe by Title  
-  **Endpoint**: `/api/recipes/search`  
-  **Method**: `GET`  
-  **Description**: Searches for recipes by title. 
-  **Query Parameter**: `title`  
-  **Response**: [Sample Response]

## Ingredients

### Get All Ingredients
- **Endpoint**: `/api/ingredients`
- **Method**: `GET`
- **Description**: Retrieves a list of all ingredients.
- **Response**: [Sample Response]		

### Get Ingredient by ID
- **Endpoint**: `/api/ingredients/{id}`
- **Method**: `GET`
- **Description**: Retrieves an ingredient by its ID.
- **Response**: [Sample Response]

### Create Ingredient
- **Endpoint**: `/api/ingredients`
- **Method**: `POST`
- **Description**: Creates a new ingredient.
- **Request Body**: 
```json
{
  "name": "Pancetta",
  "description": "Italian cured meat made from pork belly."
}

```
- **Response**: [Sample Response]

### Update Ingredient
- **Endpoint**: `/api/ingredients/{id}`
- **Method**: `PUT`
- **Description**: Updates an existing ingredient.
- **Request Body**: 
```json
{
  "id": "a2b95a44-fb6b-4d42-b2a4-5b624e53b2e1",
  "name": "Pancetta",
  "description": "Italian cured meat made from pork belly."
}

```
- **Response**: [Sample Response]

### Delete Ingredient
- **Endpoint**: `/api/ingredients/{id}`
- **Method**: `DELETE`
- **Description**: Deletes an ingredient by its ID.
- **Response**: [Sample Response]

### Search Ingredient by Name  
-  **Endpoint**: `/api/ingredients/search`  
-  **Method**: `GET`  
-  **Description**: Searches for ingredients by name. 
-  **Query Parameter**: `name`  
-  **Response**: [Sample Response]
