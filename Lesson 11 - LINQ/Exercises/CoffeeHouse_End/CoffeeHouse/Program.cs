namespace CoffeeHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Coffee> order = PopulateData();
            
            bool runProgram = true;

            while (runProgram)
            {
                PrintMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SortDrinksByPrice(order);
                        break;
                    case "2":
                        GroupDrinks(order);
                        break;
                    case "3":
                        FilterDrinks(order);
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
        }
        static void SortDrinksByPrice(List<Coffee> order)
        {
            var sortingQuery = from c in order 
                               orderby c.Price descending
                               select c;
            Console.WriteLine("---------------------");
            foreach (var coffee in sortingQuery)
            {
                Console.WriteLine($"Price: {coffee.Price} | " +
                    $"Size: {coffee.Size} | " +
                    $"Has Milk? {coffee.HasMilk} | " +
                    $"Roast: {coffee.Roast}");
            }
            Console.WriteLine("---------------------");
        }

        #region Group Drinks Methods
        static void GroupDrinks(List<Coffee> order)
        {
            PrintGroupDrinksMenu();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    GroupDrinksByPrice(order);
                    break;
                case "2":
                    GroupDrinksBySize(order);
                    break;
                case "3":
                    GroupDrinksByHasMilk(order);
                    break;
                case "4":
                    GroupDrinksByRoast(order);
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }

        static void GroupDrinksByPrice(List<Coffee> order)
        {
            var groupByPrice = from c in order
                               orderby c.Price descending
                               group c by c.Price into g
                               select g;
            foreach (var group in groupByPrice)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var c in group)
                {
                    Console.WriteLine($"    Size: {c.Size} | " +
                    $"Has Milk? {c.HasMilk} | " +
                    $"Roast: {c.Roast}");
                }
            }
        }
        static void GroupDrinksBySize(List<Coffee> order)
        {
            var groupBySize = from c in order
                              orderby c.Size ascending
                              group c by c.Size into g
                              select g;
            foreach (var group in groupBySize)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var c in group)
                {
                    Console.WriteLine($"    Price: {c.Price} | " +
                    $"Has Milk? {c.HasMilk} | " +
                    $"Roast: {c.Roast}");
                }
            }
        }
        static void GroupDrinksByHasMilk(List<Coffee> order)
        {
            var groupByHasMilk = order.OrderByDescending(c => c.Price).GroupBy(c => c.HasMilk);
            foreach (var group in groupByHasMilk)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var c in group)
                {
                    Console.WriteLine($"    Price: {c.Price} | " +
                    $"Size: {c.Size} | " +
                    $"Roast: {c.Roast}");
                }
            }
        }
        static void GroupDrinksByRoast(List<Coffee> order)
        {
            var groupByHasMilk = order.OrderBy(c => c.Roast).GroupBy(c => c.Roast);
            foreach (var group in groupByHasMilk)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var c in group)
                {
                    Console.WriteLine($"    Price: {c.Price} | " +
                    $"Size: {c.Size} | " +
                    $"Has Milk? {c.HasMilk}");
                }
            }
        }
        #endregion


        #region Filtering Methods
        static void FilterDrinks(List<Coffee> order)
        {
            PrintFilterDrinksMenu();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    FilterByPrice(order);
                    break;
                case "2":
                    FilterBySize(order);
                    break;
                case "3":
                    FilterByMilkContent(order);
                    break;
                case "4":
                    CountRoasts(order);
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }

        static void FilterByPrice(List<Coffee> order)
        {
            Console.Write("What is the minimum price? ");
            bool success = double.TryParse(Console.ReadLine(), out double price);

            var priceFilter = from c in order
                              where c.Price > price
                              orderby c.Price descending
                              select c;

            foreach(var c in priceFilter)
            {
                Console.WriteLine($"Price: {c.Price} | " +
                    $"Size: {c.Size} | " +
                    $"Has Milk? {c.HasMilk} | " +
                    $"Roast: {c.Roast}");
            }
        }
        static void FilterBySize(List<Coffee> order)
        {
            Console.Write("Which Size? ");
            string size = Console.ReadLine().ToLower();
            var sizeFilter = from c in order
                             where c.Size.ToLower() == size
                             select c.Roast;
            foreach (var roast in sizeFilter)
                Console.WriteLine($"- {roast} Roast");
        }
        static void FilterByMilkContent(List<Coffee> order)
        {
            Console.Write("Contains Milk? (yes/no) ");
            string answer = Console.ReadLine().ToLower();
            var milkFilter = order.Where(c => c.HasMilk.ToLower() == answer).Select(c => c.Size);

            foreach (var size in milkFilter)
                Console.WriteLine($"- Size: {size}");

        }
        static void CountRoasts(List<Coffee> order)
        {
            Console.Write("Which Roast? ");
            string roast = Console.ReadLine().ToLower();
            int count = order.Where(c => c.Roast.ToLower() == roast).Count();

            Console.WriteLine($"There are {count} {roast} roast drinks.");
        }

        #endregion

        #region Print Menu Methods
        static void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Sort Drinks by Price.");
            Console.WriteLine("2. Group Drinks.");
            Console.WriteLine("3. Filter the drinks in the order.");
            Console.WriteLine("4. Clear Screen.");
            Console.WriteLine("5. Quit.");
            Console.Write("Enter your choice: ");
        }
        static void PrintGroupDrinksMenu()
        {
            Console.WriteLine("How would you like to group the drinks?");
            Console.WriteLine("1. By Price.");
            Console.WriteLine("2. By Size.");
            Console.WriteLine("3. By Milk Content.");
            Console.WriteLine("4. By Roast.");
            Console.Write("Enter your choice: ");
        }
        static void PrintFilterDrinksMenu()
        {
            Console.WriteLine("How would you like to filter the drinks?");
            Console.WriteLine("1. By Price.");
            Console.WriteLine("2. By Size.");
            Console.WriteLine("3. By Milk Content.");
            Console.WriteLine("4. Count number of drinks by Roast.");
            Console.Write("Enter your choice: ");
        }
        #endregion
        static List<Coffee> PopulateData()
        {
            return new List<Coffee>()
            {
                new Coffee(6.99, "Large", true, "Dark"),
                new Coffee(8.99, "Extra Large", true, "Dark"),
                new Coffee(8.99, "Extra Large", true, "Dark"),
                new Coffee(4.99, "Small", false, "Medium"),
                new Coffee(4.99, "Small", false, "Medium"),
                new Coffee(6.49, "Medium", false, "Dark"),
                new Coffee(5.99, "Small", true, "Light"),
                new Coffee(5.99, "Small", true, "Dark"),
                new Coffee(7.99, "Extra Large", false, "Light"),
                new Coffee(7.99, "Extra Large", false, "Dark"),
                new Coffee(6.99, "Medium", false, "Light"),
                new Coffee(6.99, "Large", true, "Light"),
                new Coffee(8.99, "Extra Large", true, "Medium"),
                new Coffee(6.99, "Medium", true, "Dark"),
                new Coffee(5.99, "Small", true, "Dark")
            };
        }
    }
}
