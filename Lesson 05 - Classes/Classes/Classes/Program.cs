using System.Runtime.InteropServices;

namespace ClassesAndObjectsPart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // When creating a new object, we must use the "new" keyword.
            Person person = new Person(1, "Johan", 22);

            person.DisplayInfo();

            Console.Write("What is the person's new name? ");
            person.Name = Console.ReadLine();

            Console.Write("What is the person's new age? ");
            bool success = int.TryParse(Console.ReadLine(), out int age);

            person.Age = age;
            person.DisplayInfo();

            // When created a new List, we must include the data type of the items in the
            // list. The data type goes between the <> after List.
            // Because List is an object, we need to use the "new" keyword when creating
            // it.
            List<Person> people = new List<Person>();

            // Add new Person objects to the list

            for (int i = 0; i < 2; i++)
            {
                Console.Write("What is the person's name? ");
                string name = Console.ReadLine();

                Console.Write("What is the person's age? ");
                success = int.TryParse(Console.ReadLine(), out age);

                // create a new Person directly inside of the Add()
                people.Add(new Person(i, name, age));
            }

            foreach (Person p in people)
            {
                p.DisplayInfo();
            }
        }
    }
}
