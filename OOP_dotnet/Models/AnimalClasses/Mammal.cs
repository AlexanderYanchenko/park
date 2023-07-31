using OOP_dotnet.Models.AnimalClasses;

namespace OOP_dotnet.Models;

public class Mammal: Animal
{
    protected Mammal(string species, string name, double weight, double height) : base(species, name, weight, height, "Mammal")
    {
    }
}