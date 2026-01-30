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
            var inStockProducts = products.Where(p => p.InStock).ToList();

            // TODO: Sort by price descending
            var sorted = products.OrderByDescending(p => p.Price).ToList();

            // TODO: Project to only product names
            var names = products.Select(p => p.Name).ToList();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
