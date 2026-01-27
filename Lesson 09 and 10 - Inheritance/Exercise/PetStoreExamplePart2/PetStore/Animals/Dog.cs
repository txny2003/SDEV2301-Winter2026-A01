using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Animals
{
    public class Dog : Animal, IRunnable
    {
        private string _breed;

        public string Breed
        {
            get => _breed;
            private set => _breed = value;
        }

        public Dog(string name, int age, string breed) : base(name, age)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Breed: {Breed}";
        }

        public override void MakeNoise()
        {
            Console.WriteLine($"{Name} barks loudly.");
        }

        public void Run()
        {
            Console.WriteLine($"{Name} runs around and plays a lot.");
        }
    }
}
