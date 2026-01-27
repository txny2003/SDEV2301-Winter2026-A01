using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePolymorphism.Shapes
{
    public interface IPolygon
    {
        int NumberOfSides { get; }
        void CalculateAngleOfCorners();
    }
}
