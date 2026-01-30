using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFilteringSorting
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 1200, InStock = true },
                new Product { Name = "Mouse", Price = 25, InStock = true },
                new Product { Name = "Keyboard", Price = 75, InStock = false },
                new Product { Name = "Monitor", Price = 300, InStock = true },
            };

            // TODO: Filter only in-stock items

            // TODO: Sort by price descending

            // TODO: Project to only product names

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
