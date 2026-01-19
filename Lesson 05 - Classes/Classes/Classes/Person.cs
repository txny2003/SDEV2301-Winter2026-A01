using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ClassesAndObjectsPart1
{
    public class Person
    {
        #region Fields and Properties

        // private fields
        // fields follow the name convention _fieldName (include underscore)
        // fields should always be private
        private int _id;
        private int _age;

        // public properties
        // Properties provide encapsulation for the private fields.
        // Properties have the PascalCase naming convention.
        // Properties have access to the get/set methods that allow us to perform
        //  extra code.
        public string Name { get; set; }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 1 || value > 120)
                    throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 1 and 120.");

                // The "value" variable contains the value that the program is trying to assign
                // to the property. This only exists in the set method.
                _age = value;
            }
        }

        public int Id
        {
            get => _id;
            private set => _id = value;
        }
        #endregion

        // A constructor is a method with the same name as the class. It does not have a return value.
        // This is called whenever a new object is created.
        public Person(int id, string name, int age)
        {
            // the "this" keyword is referring to the current instance of the object.
            // It is only required when there is a naming conflict.
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Age: {Age}");
        }

        // we can override the ToString() method so that when we print the object
        // this value is returned. 
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
