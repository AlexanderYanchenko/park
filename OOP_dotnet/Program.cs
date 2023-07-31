using System;
using OOP_dotnet.Enums;
using OOP_dotnet.Models;
using OOP_dotnet.Models.AnimalClasses;
using OOP_dotnet.Models.Species;

namespace OOP_dotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var animals = new Animal[]
                {
                     new Elephant("Alex", 6000, 3.3),  
                     new Lion("Lukas", 190, 1.2),   
                     new Giraffe("Mate", 340, 7.8),   
                     new Giraffe("Messi", 370, 7.7),
                     new Elephant("Naomi", 5000, 5.3),
                     new Owl("Jiro", 10, 0.2)
                };
                
                var safariPark = new SafariPark();
                safariPark.SeparateAnimals(animals);

                // Count the number of different animal species
                Console.WriteLine("------------- Counting -----------");
                Console.WriteLine($"There are {safariPark.Mammals.CountOfUniqueSpecies()} different animal species in the Mammals sections \n" +
                                  $"and  {safariPark.Birds.CountOfUniqueSpecies()} different animal species in the Birds sections");
                Console.WriteLine("\n");
                
                // Sort animals.
                Console.WriteLine("------------- Sort animals -----------");
                Console.Write("1. Enter the parameters (Species, Name, Weight, or Height) that you want to sort: ");
                var sortParameter = Console.ReadLine() ?? "Species";
                
                Console.Write("2. Enter the type of sorting (asc, or desc): ");
                var sortTypeInput = Console.ReadLine() ?? "asc";

                if (!Enum.TryParse(sortTypeInput, ignoreCase: true, out Sort sortType))
                {
                    Console.WriteLine("Oops, something went wrong");
                }

                var sortedAnimals = safariPark.SortAnimals(sortParameter, sortType);
                
                Console.WriteLine("*** Here are the sorted animals based on the provided parameters: ");
                
                foreach (var animal in sortedAnimals)
                {
                    Console.WriteLine("Species: {0}, Name: {1}, Weight: {2}, Height: {3}", animal.Species,animal.Name, animal.Weight, animal.Height);
                }
                
                Console.WriteLine("\n");
                
                // Filter animals by one of the parameter
                Console.WriteLine("------------- Filter animals -----------");
                Console.Write("1. Enter the parameters (Species, Name, Weight, or Height) of animal that you want to search: ");
                
                var filterParameter = Console.ReadLine() ?? "Name";
                
                Console.Write("2. Enter the characteristics of animal: ");
                var search = Console.ReadLine() ?? "a";

                var filteredAnimals = safariPark.FilterAnimalsByParameter(filterParameter, search);

                Console.WriteLine("*** Here are the searched animals: ");
                
                foreach (var animal in filteredAnimals)
                {
                    Console.WriteLine("Species: {0}, Name: {1}, Weight: {2}, Height: {3}", animal.Species, animal.Name, animal.Weight, animal.Height);
                }
            } catch (Exception e)
            {
                Console.WriteLine("Invalid parameters!");
            }

        }
    }
}