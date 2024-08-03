# Domain Models

## Recipe

```csharp
class Recipe: AggregateRoot
{
	Result<Recipe> Create;
	void AddIngredient();
	void AddStep();
	void RemoveIngredient();
	void RemoveLastStep();
	void UpdateStepDescription();
}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"title": "Carbonara Pasta",
	"description": "Traditional Carbonara recipe",
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
			"stepDescription": "First you need to ..."
		}
	]
}
```

---

## Ingredient

```csharp
class Ingredient: AggregateRoot
{
	Result<Ingredient> Create();
}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Potato",
	"description": "The potato is a starchy root vegetable native to the Americas that is consumed as a staple food in many parts of the world. 
					Potatoes are tubers of the plant Solanum tuberosum, a perennial in the nightshade family Solanaceae."
}
```

---