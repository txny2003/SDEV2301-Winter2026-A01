using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Animals
{
    public abstract class Animal
    {
        private string _name;
        protected int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public virtual int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 20)
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid value for Age");
                _age = value;
            }
        }
        
        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public abstract void MakeNoise();

        public virtual void Pet()
        {
            Console.WriteLine($"You pet {Name}.");
        }
    }
}
