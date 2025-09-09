using FoodRecipes.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodRecipes.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.OwnsOne(user => user.Email, type =>
        {
            type.Property(userEmail => userEmail.Value)
                .HasColumnName("Email")
                .HasColumnType("TEXT")
                .IsRequired();
        });

        builder.OwnsOne(user => user.Password, type =>
        {
            type.Property(userPassword => userPassword.Value)
                .HasColumnName("Password")
                .HasColumnType("TEXT")
                .IsRequired();
        });
    }
}