using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Animals
{
    public class Cat : Animal, IRunnable
    {
        private string _breed;
        private int _angerLevel;


        public override int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 30)
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid value for Age");
                _age = value;
            }
        }

        public string Breed
        {
            get => _breed;
            private set => _breed = value;
        }

        public int AngerLevel
        {
            get => _angerLevel;
            private set => _angerLevel = value;
        }

        public Cat(string name, int age, string breed) : base(name, age)
        {
            Random rand = new Random();
            this.Breed = breed;
            this.AngerLevel = rand.Next(1, 101);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Breed: {Breed}";
        }
        public override void MakeNoise()
        {
            Console.WriteLine($"{Name} purrs quietly.");
        }

        public void Run()
        {
            Console.WriteLine($"{Name} runs around.");
        }
    }
}
