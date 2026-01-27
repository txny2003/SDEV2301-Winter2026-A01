# Exercise Inheritance and Polymorphism
# Pet Store

Expand on the Pet Store console application by including inheritance.

## Requirements for Classes and Interfaces

1. Create two new classes called `Animal` and `Fish` in the Animals subfolder with the following details:
    - Animal
        - Fields
            - private string _name;
            - protected int _age;
        - Properties
            - `Name`: String
            - `Age`: Int (make it virtual)
                - Must be from 1-20
        - Methods
            - Constructor sets the `Name` and `Age`
            - abstract method `MakeNoise()`
            - virtual void method `Pet` which prints "You pet " followed by the animal's `Name`.
    - Fish
        - Properties
            - `Size`: String
        - Methods
            - override `ToString()` to print the Name, Age, and Size of the fish.
            - Constructor takes name, age, size, and freshWaterOnly (boolean) parameters
    
2. Create three public interfaces:
    - `IRunnable`
        - Contains the void method `Run()`
    - `IFlyable`
        - Contains the int property `Wingspan`
        - Contains the void method `Fly()`
    - `ISwimmable`
        - Contains the bool property `FreshWaterOnly`
        - Contains the void method `Swim()`
2. Make the `Dog`, `Cat`, `Fish`, and `Bird` classes inherit from `Animal`. Remove any code from the derived classes that belongs to the `Animal` base class. Override the MakeNoise() method inherited from `Animal`.
3. Implement the `IRunnable` and `IFlyable` interfaces on the `Bird` class.
4. Implement the `IRunnable` interface on the `Dog` and `Cat` classes.
5. Implement the `ISwimmable` interface on the `Fish` class.
6. Override the Age property in `Cat` and `Bird` so that Cats can live up to 30 years and Birds can live up to 80 years.
7. The Implementation for the Interfaces should be as follows:
    - `IRunnable`
        - `Run()` should print the animal's name and " runs around"
    - `IFlyable`
        - `Fly()` should print the animal's name and wingspan
        - `Wingspan` should be initialized in the object's constructor based on a parameter in the constructor.
    - `ISwimmable`
        - `Swim()` should print the animal's name and " swims around" and in what type of water they swim in (Fresh or Salty).
        - `FreshWaterOnly` should be initialized in the object's constructor based on a parameter in the constructor.

## Requirements for Main Program

1. At the top of the `Main()` method, create a new `List<Animal>` called `animals`. This will hold all of the animals in the program.
2. In the `while` loop of the main program:
    - add a new option for viewing the animals in the list.
    - add a new option for listening to all of the animals.
3. Method Updates:
    - `PrintMainMenu()`
        - include the new option `View Animals`.
        - include the new option `Listen to Animals`.
    - `PrintSelectMenu()`
        - include the new option `Add Fish`
    - `AddAnimal(List<Animal> animals)`
        - Add the parameter `List<Animal> animals` to the method definition.
        - include a new option in the switch to add a fish.
    - `AddDog(List<Animal> animals)`
        - Add the parameter `List<Animal> animals` to the method definition.
        - Remove the `MakeNoise()` call.
        - Add the newly created `Dog` object to the `animals` list.
    - `AddCat(List<Animal> animals)`
        - Add the parameter `List<Animal> animals` to the method definition.
        - Remove the `MakeNoise()` call.
        - Add the newly created `Cat` object to the `animals` list.
    - `AddBird(List<Animal> animals)`
        - Add the parameter `List<Animal> animals` to the method definition.
        - Add a prompt to enter the wingspan.
        - Remove the `MakeNoise()` call.
        - Add the newly created `Bird` object to the `animals` list.
4. New Methods:
    - `GetBool(string prompt)`: prompts the user for an boolean using the `prompt` parameter. _Safely_ gets an input from the user implemented proper error handling. Returns the boolean the user entered.
    - `AddFish(List<Animal> animals)`: void method that adds a new fish to the list of animals
    - `ListenToAnimals(List<Animal> animals)`: void method that loops through all animals and calls the `MakeNoise()` method on each animal.
    - `ViewAnimals(List<Animal> animals)`:
        - Loop through all of the objects in the `animals` list.
        - Print the animal details to the console, making use of the ToString() override.
        - If the animal implements `IRunnable`, call the `Run()` method.
        - If the animal implements `IFlyable`, call the `Fly()` method
        - If the animal implements `ISwimmable`, call the `Swim()` method.

Sample Output - Adding Animal:
```
Pet Store.
1. Add Animal
2. View Animals
3. Listen to Animals
4. Quit
Enter choice: 1
Select Animal
1. Add dog.
2. Add cat.
3. Add bird.
4. Add fish.
Enter choice: 1
Enter the name: Rover
Enter the age: 3
Enter the breed: Test
Added Name: Rover, Age: 3, Breed: Test
```

Sample Output - View Animals:

```
Pet Store.
1. Add Animal
2. View Animals
3. Listen to Animals
4. Quit
Enter choice: 2
Name: Rover, Age: 3, Breed: Test
Rover runs around and plays a lot.
Name: Boxie, Age: 14, Breed: Tabby
Boxie runs around.
Name: Flybird, Age: 30, Species: Parrot
Flybird runs around.
Flybird flies high in the sky with a wingspan of 3.
Name: Nemo, Age: 2, Size: Large
Nemo swims quickly in fresh water.
```

Sample Output - Listen to Animals:

```
Pet Store.
1. Add Animal
2. View Animals
3. Listen to Animals
4. Quit
Enter choice: 3
Rover barks loudly.
Boxie purrs quietly.
Flybird chirps excitedly.
Nemo makes a splashy sound.
```