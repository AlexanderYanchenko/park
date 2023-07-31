using OOP_dotnet.Models.AnimalClasses;

namespace OOP_dotnet.Models;

public class Section
{
    public Animal[] Animals { get; set; }

    public Section()
    {
        Animals = Array.Empty<Animal>();
    }

    public void Push(Animal animal)
    {
        var arr = new Animal[Animals.Length + 1];

        for (var i = 0; i < Animals.Length; i++)
        {
            arr[i] = Animals[i];
        }

        arr[^1] = animal;
        Animals = arr;
    }

    public int CountOfUniqueSpecies()
    {
        return Animals.Select(animal => animal.Species).Distinct().Count();
    }
}