using System.Text;
using System.Transactions;

namespace Methods
{
    internal class Program
    {
        /// <summary>
        /// Methods in C# are separate blocks of code that can be executed many time by using their name. 
        /// This is C# name for functions.
        /// 
        /// The return type must be include in the method definition. If the function returns nothing, then the return
        /// type will be 'void'.
        /// 
        /// Additionally, the access modifier (public, protected, private, internal) must be included in most cases.
        /// 
        /// Methods following the PascalCase naming convention.
        /// </summary>
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                // to call a method, use its name followed by parentheses.
                PrintMenu();
                string choice = Console.ReadLine().ToUpper();

                // switch statements analyze a constant (like a string) and will execute blocks of code based on
                // the value
                switch (choice)
                {
                    // use the case keyword and the value you are checking to execute the code block underneath it
                    // The code inside of a case statement does not require curly braces {}, but does require a break
                    // statement at the end.
                    case "A":
                        Console.Write("What is the radius of the circle (cm)? ");
                        double radius = GetDouble();
                        double area = CalculcateAreaOfCircle(radius);
                        Console.WriteLine($"The area of the circle is: {area} square cm.");
                        break;
                    case "B":
                        string brush = GetBrushAndPaintColor(out string color);
                        Console.WriteLine($"You grab a {brush} brush with {color} paint and start painting.");
                        break;
                    case "C":
                        BuyItemOnline();
                        break;
                    case "D":
                        running = false;
                        break;

                    // use "default" to execute code when none of the cases match.
                    default:
                        Console.WriteLine("That is not a valid option. Try again.");
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("A. Calculate area of a circle.");
            Console.WriteLine("B. Get a brush and a paint color.");
            Console.WriteLine("C. Buy item online.");
            Console.WriteLine("D. Quit.");
            Console.Write("Enter Choice: ");
        }
        /// <summary>
        /// Calculates the area of a circle based on the radius
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        /// <returns>The area of the circle</returns>
        static double CalculcateAreaOfCircle(double radius) // data types must be included in parameters
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        /// <summary>
        /// Gets the brush size that the user wants to paint with.
        /// Also sets the color parameter.
        /// </summary>
        /// <param name="color">The color that the user wants to paint</param>
        /// <returns>Brush size</returns>
        static string GetBrushAndPaintColor(out string color) 
        {
            
            Console.Write("Which size of brush would you like? (small, medium, large) ");
            string brush = Console.ReadLine();

            Console.Write("Which paint color would you like to use? ");
            color = Console.ReadLine();

            return brush;
        }
        /// <summary>
        /// Safely gets a double from the console.
        /// </summary>
        /// <returns>The double that the user inputs.</returns>
        static double GetDouble()
        {
            do
            {
                Console.Write("Please enter a double: ");
                bool success = double.TryParse(Console.ReadLine(), out double result);

                if (success)
                    return result;

                Console.WriteLine("That value is not a double. Try again.");

            } while (true);
        }

        /// <summary>
        /// Prints the item summary in a user friendly way.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cost"></param>
        /// <param name="shippingType" default="Air"></param>
        /// <param name="color" default="Black"></param>
        static void ItemSummary(string item, double cost, string shippingType = "Air", string color = "Blue") 
        {
            // Parameters can have default values by assigning a value to it in the method definition
            // This makes the parameters optional, if they are not provided as part of the method call, the
            // default value will be used.

            Console.WriteLine($"Item:            {item}");
            Console.WriteLine($"Cost:            {cost:C}");
            Console.WriteLine($"Shipping Type:   {shippingType}");
            Console.WriteLine($"Color:           {color}");
        }
        /// <summary>
        /// Prompts the user for the item they wish to purchase and its cost. It will then print the item summary
        /// </summary>
        static void BuyItemOnline()
        {
            Console.Write("Which item would you like to buy? ");
            string item = Console.ReadLine();

            Console.Write("How much does it cost? ");
            double price = GetDouble();

            // if you do not know the order of the parameters, you can use their names instead.
            // When using named parameters, you do not need to worry about order.
            ItemSummary(cost: price, item: item);
        }
    }
}
