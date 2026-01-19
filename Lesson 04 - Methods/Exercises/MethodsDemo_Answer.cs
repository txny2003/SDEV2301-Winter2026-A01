namespace Lesson04.ConsoleApp
{
	// MethodsDemo.cs
	// Demonstrates defining and calling methods in C#.

	using System;

	class MethodsDemo
	{
		static void Main()
		{
			Console.WriteLine("=== Methods Demo ===");

			// Example 1: Call a simple method with no parameters
			PrintGreeting();

			// Example 2: Call a method with parameters
			Console.Write("Enter the length of a rectangle: ");
			double length = double.Parse(Console.ReadLine());

			Console.Write("Enter the width of a rectangle: ");
			double width = double.Parse(Console.ReadLine());

			double area = CalculateRectangleArea(length, width);
			Console.WriteLine($"The area of the rectangle is {area}");

			// Example 3: Call a method that validates input
			int age = GetValidatedAge();
			Console.WriteLine($"Your age is recorded as {age}");
		}

		// A simple method with no parameters and no return value
		static void PrintGreeting()
		{
			Console.WriteLine("Hello from a method!");
		}

		// A method with parameters and a return value
		static double CalculateRectangleArea(double length, double width)
		{
			return length * width;
		}

		// A method that validates user input
		static int GetValidatedAge()
		{
			int age;
			do
			{
				Console.Write("Enter your age (1–120): ");
				string input = Console.ReadLine();
				if (int.TryParse(input, out age) && age >= 1 && age <= 120)
				{
					return age; // valid input
				}
				Console.WriteLine("Invalid age. Please try again.");
			} while (true);
		}
	}

}
