using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Recipes.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipes.Persistence.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);

        // Owned type: RecipeTitle
        builder.OwnsOne(r => r.Title, t =>
        {
            t.Property(x => x.Value)
                .HasColumnName("Title")
                .HasColumnType("TEXT")
                .IsRequired();
        });

        // Owned type: RecipeDescription
        builder.OwnsOne(r => r.Description, d =>
        {
            d.Property(x => x.Value)
                .HasColumnName("Description")
                .HasColumnType("TEXT")
                .IsRequired();
        });

        // Owned collection: RecipeIngredient
        builder.OwnsMany(r => r.Ingredients, ing =>
        {
            ing.WithOwner().HasForeignKey("RecipeId");

            ing.HasKey("RecipeId", nameof(RecipeIngredient.IngredientId));

            ing.Property(x => x.IngredientId)
                .HasColumnName("IngredientId");

            ing.Property(x => x.Quantity)
                .HasConversion(
                    q => q.Value,
                    v => new IngredientQuantity(v)
                )
                .HasColumnName("Quantity")
                .HasColumnType("REAL")
                .IsRequired();

            ing.Property(x => x.Unit)
                .HasConversion<string>()
                .HasColumnName("Unit")
                .HasColumnType("TEXT")
                .IsRequired();

            ing.ToTable("RecipeIngredients");
        });

        // Owned collection: RecipeStep
        builder.OwnsMany(r => r.Steps, step =>
        {
            step.WithOwner().HasForeignKey("RecipeId");

            step.HasKey("RecipeId", nameof(RecipeStep.Value));

            step.Property(x => x.Value)
                .HasColumnName("Step")
                .HasColumnType("TEXT")
                .IsRequired();

            step.ToTable("RecipeSteps");
        });
    }
}
