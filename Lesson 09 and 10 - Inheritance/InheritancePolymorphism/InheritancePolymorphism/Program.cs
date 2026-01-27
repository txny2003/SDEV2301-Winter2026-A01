using InheritancePolymorphism.Shapes;
using System.Reflection.Metadata.Ecma335;

namespace InheritancePolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Examples of inheritance
            Circle circle = new Circle("Green", 20);
            Console.WriteLine($"The area of the {circle.Color} circle is {circle.GetArea()}");
            circle.Describe();

            Rectangle rectangle = new Rectangle("Blue", 10, 24);
            Console.WriteLine($"The area of the {rectangle.Color} rectangle is {rectangle.GetArea()}");
            rectangle.Describe();
            Console.WriteLine("---------");
            //Arrays: A collection of fixed size.

            // Two ways to create
            // 1. declare an empty array with the number of items allowed. Every item in the array is initialize to its default value
            //    which is "null" in the case of objects

            // <DataType> <name> = new <DataType>[<size>]
            Circle[] circles = new Circle[3];

            
            circles[0] = new Circle("Orange", 5);
            circles[1] = new Circle("Purple", 10);

            foreach (Circle c in circles)
            {
                if (c == null)
                    continue;
                Console.WriteLine($"The area of the {c.Color} circle is {c.GetArea()}");
                c.Describe();
            }

            // 2. Declare an array with starting values. This will determine the fixed size at compile time.
            Console.WriteLine("---------");
            Rectangle[] rectangles =
            {
                new Rectangle("Blue", 10, 20),
                new Rectangle("Pink", 5, 7),
                new Rectangle("Lavendar", 3, 4)
            };

            // you can use var to simplify the foreach loop, since the data type is gathered from the collection
            foreach (var r in rectangles)
            {
                Console.WriteLine($"The area of the {r.Color} rectangle is {r.GetArea()}");
                r.Describe();
            }
            Console.WriteLine("---------");

            // POLYMORPHISM
            // Items with the same base class are related, and group together in collections of a base class.

            List<Shape> shapes = new List<Shape>
            {
                new Circle("Blue", 4),
                new Rectangle("Green", 10, 4),
                new Triangle(10, 4, "Dreary Yellow"),
                new Rectangle("Aubergine", 3, 12)
            };

            string color = "Red";

            // Because we are passing "color" by value, the color variable in
            // this Main() method will not have its value changed.
            AddCircle(shapes, color);

            foreach (var s in shapes)
            {
                // Call all of the base methods and properties in the Shape class
                // Depending on the derived class, the overrides will be called.
                Console.WriteLine($"The area of the {s.Color} shape is {s.GetArea()}");
                s.Describe();

                // check if the Shape is a Circle
                if (s is Circle)
                {
                    // cast the shape to a Circle before accessing the Radius property
                    Circle c = (Circle)s;
                    Console.WriteLine($"The radius is {c.Radius}");
                }
                // Check if the Shape implements the IPolygon Interface
                if (s is IPolygon)
                {
                    // After casting, we only have access to properties to
                    // methods that are defined in the IPolygon interface
                    var p = (IPolygon)s;
                    Console.WriteLine($"This shape has {p.NumberOfSides} sides.");
                    p.CalculateAngleOfCorners();
                }
            }
        }

        static void AddCircle(List<Shape> shapes, string color)
        {
            // "color" is passed by value, meaning that any changes made inside of
            // the AddCircle() method do not change the value variable in the
            // calling function, in this case Main().
            color = "Orange";

            // The shapes list is passed by reference, meaning that the location
            // of the List in memory is passed, allowing us to change the values
            // in the calling function (adding a new item to the List).
            shapes.Add(new Circle(color, 5));

            
        }
    }
}
