using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using OOP_dotnet.Enums;
using OOP_dotnet.Models;
using OOP_dotnet.Models.AnimalClasses;

namespace OOP_dotnet
{
    public class SafariPark
    {
        public Section Mammals { get;}
        public Section Birds { get;}

        public SafariPark()
        {
            Mammals = new Section();
            Birds = new Section();
        }

        public void SeparateAnimals(Animal[] animals)
        {
            foreach (var animal in animals)
            {
                switch (animal.AnimalClass)
                {
                    case "Mammal":
                        Mammals.Push(animal);
                        break;
                    case "Bird":
                        Birds.Push(animal);
                        break;
                }
            }
        }
        
        public Animal[] SortAnimals(string sortParameter, Sort sortType)
        {
            var animals = Mammals.Animals.Concat(Birds.Animals).ToArray();
            switch (sortParameter.ToLower())
            {
                case "weight":
                    Array.Sort(animals, (a1, a2) => sortType == Sort.Asc ? a1.Weight.CompareTo(a2.Weight) : a2.Weight.CompareTo(a1.Weight));
                    break;
                case "height":
                    Array.Sort(animals, (a1, a2) => sortType == Sort.Asc ? a1.Height.CompareTo(a2.Height) : a2.Height.CompareTo(a1.Height));
                    break;
                case "name":
                    Array.Sort(animals, (a1, a2) => sortType == Sort.Asc ? a1.Name.CompareTo(a2.Name) : a2.Name.CompareTo(a1.Name));
                    break;
                case "species":
                    Array.Sort(animals, (a1, a2) => sortType == Sort.Asc ? a1.Species.CompareTo(a2.Height) : a2.Species.CompareTo(a1.Height));
                    break;
            }

            return animals;
        }
        
        
        public Animal[] FilterAnimalsByParameter(string filterParameter, string searchString)
        {
            var filteredMammals = FilterAnimalsInSection(Mammals, filterParameter, searchString);
            var filteredBirds = FilterAnimalsInSection(Birds, filterParameter, searchString);

            return filteredMammals.Concat(filteredBirds).ToArray();
        }

        private Animal[] FilterAnimalsInSection(Section section, string filterParameter, string searchString)
        {
            switch (filterParameter.ToLower())
            {
                case "species":
                    return section.Animals.Where(a => a.Species.Contains(searchString)).ToArray();
                case "name":
                    return section.Animals.Where(a => a.Name.Contains(searchString)).ToArray();
                case "weight":
                    if (double.TryParse(searchString, out var weight))
                    {
                        return section.Animals.Where(a => a.Weight == weight).ToArray();
                    }
                    break;
                case "height":
                    if (double.TryParse(searchString, out var height))
                    {
                        return section.Animals.Where(a => a.Height == height).ToArray();
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid filter Parameter");
            }

            return Array.Empty<Animal>();
        }
    }

}

