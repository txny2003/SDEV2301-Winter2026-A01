using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Animals
{
    public class Bird : Animal, IRunnable, IFlyable
    {
        private string _species;

        public override int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 80)
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid value for Age");
                _age = value;
            }
        }
        public string Species
        {
            get => _species;
            private set => _species = value;
        }
        public int Wingspan { get; set; }

        public Bird(string name, int age, string species, int wingspan) : base (name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Species = species;
            this.Wingspan = wingspan;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Species: {Species}";
        }
        public override void MakeNoise()
        {
            Console.WriteLine($"{Name} chirps excitedly.");
        }

        public void Run()
        {
            Console.WriteLine($"{Name} runs around.");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies high in the sky with a wingspan of {Wingspan}.");
        }
    }
}
