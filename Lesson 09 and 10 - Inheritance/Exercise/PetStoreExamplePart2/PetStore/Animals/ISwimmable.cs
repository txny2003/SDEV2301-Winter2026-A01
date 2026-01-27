using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Animals
{
    public interface ISwimmable
    {
        bool FreshWaterOnly { get; set; }
        void Swim();
    }
}
