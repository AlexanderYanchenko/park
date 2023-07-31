using OOP_dotnet.Models.AnimalClasses;

namespace OOP_dotnet.Models;

public class Bird: Animal
{
    protected Bird(string species, string name, double weight, double height) : base(species, name, weight, height, "Bird")
    {
    }
}