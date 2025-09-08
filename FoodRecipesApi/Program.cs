using FoodRecipes.Application;
using FoodRecipes.Persistence;
using FoodRecipes.Presentation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=foodrecipes.db"));

// Adding Layer Dependencies
builder.Services.AddApplication();
builder.Services.AddPersistence();

//Adding the controllers from the presentation layer
builder.Services.AddControllers().AddApplicationPart(PresentationAssemblyReference.Assembly);
//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); // Applies any pending migrations
}

app.Run();
