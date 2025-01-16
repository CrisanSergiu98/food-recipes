using System.Reflection;

namespace FoodRecipes.Presentation;

// Static class for referencing the presentation assembly
public static class PresentationAssemblyReference
{
    // Static readonly field to hold the assembly reference
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
