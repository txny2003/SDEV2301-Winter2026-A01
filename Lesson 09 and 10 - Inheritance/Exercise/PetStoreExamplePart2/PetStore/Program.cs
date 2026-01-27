using PetStore.Animals;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PetStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            bool running = true;
            while (running)
            {
                PrintMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAnimal(animals);
                        break;
                    case "2":
                        ViewAnimals(animals);
                        break;
                    case "3":
                        ListenToAnimals(animals);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

        }
        static void PrintMainMenu()
        {
            Console.WriteLine("Pet Store.");
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. View Animals");
            Console.WriteLine("3. Listen to Animals");
            Console.WriteLine("4. Quit");
            Console.Write("Enter choice: ");
        }
        static void PrintSelectMenu()
        {
            Console.WriteLine("Select Animal");
            Console.WriteLine("1. Add dog.");
            Console.WriteLine("2. Add cat.");
            Console.WriteLine("3. Add bird.");
            Console.WriteLine("4. Add fish.");
            Console.Write("Enter choice: ");
        }

        static void AddAnimal(List<Animal> animals)
        {
            PrintSelectMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddDog(animals);
                    break;
                case "2":
                    AddCat(animals);
                    break;
                case "3":
                    AddBird(animals);
                    break;
                case "4":
                    AddFish(animals);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        static void ViewAnimals(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
                if (animal is IRunnable)
                {
                    IRunnable runner = (IRunnable) animal;
                    runner.Run();
                }
                if (animal is IFlyable)
                {
                    IFlyable flyer = (IFlyable) animal;
                    flyer.Fly();
                }
                if (animal is ISwimmable)
                {
                    ISwimmable swimmer = (ISwimmable)animal;
                    swimmer.Swim();
                }
            }
        }
        static void ListenToAnimals(List<Animal> animals)
        {
            foreach (Animal animal in animals)
                animal.MakeNoise();
        }
        static void AddDog(List<Animal> animals)
        {
            string name = GetString("Enter the name: ");
            int age = GetInt("Enter the age: ");
            string breed = GetString("Enter the breed: ");

            Dog dog = new Dog(name, age, breed);
            Console.WriteLine($"Added {dog}");
            animals.Add(dog);
        }
        static void AddCat(List<Animal> animals)
        {
            string name = GetString("Enter the name: ");
            int age = GetInt("Enter the age: ");
            string breed = GetString("Enter the breed: ");

            Cat cat = new Cat(name, age, breed);
            Console.WriteLine($"Added {cat}");
            animals.Add(cat);
        }
        static void AddBird(List<Animal> animals)
        {
            string name = GetString("Enter the name: ");
            int age = GetInt("Enter the age: ");
            string species = GetString("Enter the species: ");
            int wingspan = GetInt("Enter the wingspan: ");

            Bird bird = new Bird(name, age, species, wingspan);
            Console.WriteLine($"Added {bird}");
            animals.Add(bird);
        }
        static void AddFish(List<Animal> animals)
        {
            string name = GetString("Enter the name: ");
            int age = GetInt("Enter the age: ");
            string size = GetString("Enter the size: ");
            bool freshWaterOnly = GetBool("Is it a fresh water fish? ");

            Fish fish = new Fish(name, age, size, freshWaterOnly);
            Console.WriteLine($"Added {fish}");
            animals.Add(fish);
        }

        static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static int GetInt(string prompt) 
        {
            bool success = false;
            int val = 0;

            do
            {
                Console.Write(prompt);
                success = int.TryParse(Console.ReadLine(), out val);
                if (!success)
                    Console.WriteLine("Invalid input.");

            } while (!success);
            return val;
        }
        static bool GetBool(string prompt)
        {
            bool success = false;
            bool val = false;

            do
            {
                Console.Write(prompt);
                success = bool.TryParse(Console.ReadLine(), out val);
                if (!success)
                    Console.WriteLine("Invalid input.");

            } while (!success);
            return val;
        }
    }
}
