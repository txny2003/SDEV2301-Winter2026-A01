using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePolymorphism.Shapes
{
    // Base class (parent)
    public abstract class Shape
    {
        // The "protected" access modifier allows this class and all derived classes access to this field.
        protected string _color;
        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public Shape(string color)
        {
            Color = color;
        }

        // Virtual/abstract method to be overridden by derived classes
        public abstract double GetArea();

        public virtual void Describe()
        {
            Console.WriteLine($"This is a {Color} shape.");
        }
    }

    // Derived class: Circle
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string color, double radius) : base(color)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;

        public override void Describe()
        {
            Console.WriteLine($"This is a {Color} circle with radius {Radius}.");
        }
    }
    // Derived class: Rectangle
    public class Rectangle : Shape, IPolygon
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public int NumberOfSides => 4;

        public Rectangle(string color, double length, double width) : base(color)
        {
            Length = length;
            Width = width;
        }

        public override double GetArea() => Length * Width;

        public override void Describe()
        {
            Console.WriteLine($"This is a {Color} rectangle {Length} x {Width}.");
        }

        public void CalculateAngleOfCorners()
        {
            double angleOfCorners = 360.0 / NumberOfSides;
            Console.WriteLine($"The angles of a rectangle are {angleOfCorners} degrees.");
        }
    }
}
