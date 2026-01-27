using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PetStore.Animals
{
    public class Fish : Animal, ISwimmable
    {
        public string Size { get; set; }
        public bool FreshWaterOnly { get; set; }

        public Fish(string name, int age, string size, bool freshWaterOnly) : base(name, age)
        {
            this.Size = size;
            this.FreshWaterOnly = freshWaterOnly;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Size: {Size}";
        }
        public override void MakeNoise()
        {
            Console.WriteLine($"{Name} makes a splashy sound.");
        }

        public void Swim()
        {
            string waterType = this.FreshWaterOnly ? "fresh" : "salty";
            Console.WriteLine($"{Name} swims quickly in {waterType} water.");
        }
    }
}
