using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Animals
{
    public interface IFlyable
    {
        int Wingspan { get; set; }
        void Fly();
    }
}
