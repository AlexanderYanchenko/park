namespace OOP_dotnet.Models.AnimalClasses
{
	public class Animal
	{
        public string Species { get; set; }
        public string AnimalClass { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        protected Animal(string species, string name, double weight, double height, string animalClass)
        {
	        Species = species;
	        Name = name;
	        Weight = weight;
	        Height = height;
	        AnimalClass = animalClass;
        }
	}
}

