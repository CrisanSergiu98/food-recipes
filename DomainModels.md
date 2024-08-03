# Domain Models

## Recipe

```csharp
class Recipe: AggregateRoot
{
	Result<Recipe> Create;
	void AddIngredient(Ingredient ingredient, float Quantity, Mesurement mesurement);
	void AddStep(string text);
	void RemoveIngredient(Ingredient ingredient);
	void RemoveStep(int stepNumber);
}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"title": "Carbonara Pasta",
	"pictureUrl": "www.pictureswithpasta.com/id=carbonara:)",
	"description": "Traditional Carbonara recipe"
	"recipeIngredients": [
		{
			"ingredientId": "00000000-0000-0000-0000-000000000000",
			"quantity": 250,
			"mesurement": "gram"
		}
	],
	"recipeSteps": [
		{
			"stepNumber": 1,
			"stepText": "First you need to ..."
		}
	]
}
```

### RecipeIngredient

```json
{
	"recipeId":  "00000000-0000-0000-0000-000000000000",
	"ingredientId": "00000000-0000-0000-0000-000000000000",
	"quantity": 250,
	"mesurement": "gram"
}
```

### RecipeStep

```json
{
	"recipeId":  "00000000-0000-0000-0000-000000000000",
	"stepNumber": 1,
	"stepText": "First you need to ..."
}
```

---

## Ingredient

```csharp
class Ingredient: AggregateRoot
{
	Result<Ingredient> Create(IngredientName name, PictureURL pictureUrl, IngredientDescription description);
}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Potato",
	"pictureURL": "www.potatopictures.com/",
	"description": "The potato is a starchy root vegetable native to the Americas that is consumed as a staple food in many parts of the world. 
					Potatoes are tubers of the plant Solanum tuberosum, a perennial in the nightshade family Solanaceae."
}
```

---