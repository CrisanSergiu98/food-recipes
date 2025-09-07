using FoodRecipes.Domain.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipes.Persistence.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Id);

        // Map IngredientName as an owned (complex) type
        builder.OwnsOne(i => i.Name, nameCfg =>
        {
            nameCfg.Property(n => n.Value)
                .HasColumnName("Name")
                .HasColumnType("TEXT")
                .IsRequired();
        });

        // Map IngredientDescription similarly
        builder.OwnsOne(i => i.Description, descCfg =>
        {
            descCfg.Property(d => d.Value)
                .HasColumnName("Description")
                .HasColumnType("TEXT")
                .IsRequired();
        });
    }
}

