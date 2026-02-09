# EF Core With Migration

Create the models, relationships, and the database using Entity Framework Core.

Uncomment the code in the Main() method as required as you progress through the exercise.

Note: If you want to start over, just delete the `residential.db` file and rerun the program.

## Step 1: Create Database
1. Install the required NuGet packages for EF Core
    - `Microsoft.EntityFrameworkCore`
    - `Microsoft.EntityFrameworkCore.Sqlite`
    - `Microsoft.EntityFrameworkCore.Design`
2. Create the following models (as public classes) with the appropriate properties:
    - `Neighborhood`
        - `Id` (int)
        - `Name` (string)
            - Initialize to an empty string
        - `District` (char)
        - `Houses` (List<House>)
            - Initialize to an empty list using `new()`
    - `House`
        - `Id` (int)
        - `Address` (string)
            - Initialize to an empty string
        - `PostalCode` (string)
            - Initialize to an empty string
        - `NeighborhoodId` (int)
        - `Neighborhood` (nullable Neighborhood)
3. Create the `ResidentialContext` class to manage the database set up.
    - Inherits from `DbContext`
    - `public` Properties:
        - Neighborhoods (DbSet<Neighborhood>)
            - Initialize as a Set<Neightborhood>
        - Houses (DbSet<House>)
            - Initialize as a Set<House>
    - Method Overrides:
        - `OnConfiguring()`
            - set the `UseSqlite` method to use a new database file called `residential.db`
        - `OnModelCreating()`
            - Add the following settings on the `House` entity:
                - `Address` is required and has a maximum length of 80 characters
                - `PostalCode` is required and has a maximum length of 6 characters
            - Add the following settings on the `Neighborhood` entity:
                - `Name` is required and has a maximum length of 100 characters
                - `District` is required
                - Establish a One-To-Many relationship with the `House` entity, using the `NeighborhoodId` property in `House` as a Foreign Key
                - Ensure that the delete functionality is cascading
4. Migrate the database using the required dotnet CLI commands:
    - `dotnet tool install --global dotnet-ef` (Only do this if you haven't done it yet in another project)
    - `dotnet ef migrations add InitialCreate`
    - `dotnet ef database update`

## Step 2: Implement Database Operations
In the `Main()` method:
    - Create a new Residential context called `context`
    - Enable migration using the `Migrate()` method

Create the following methods

1. `CreateNeighborhood(ResidentialContext context)`
    - returns nothing
    - If there aren't any Neighborhoods, add the following neighborhood to the database:
    ```
    new Neighborhood
    {
        Name = "Garneau",
        District = 'P'
    };
    ```
2. `GetOnlyNeighborhoodByName(ResidentialContext context, string name)`
    - returns a `Neighborhood` object
    - Return only the neighborhood (not any houses) from the database based on the name provided
    - Return null if the neighborhood does not exist
3. `CreateHouses(ResidentialContext context, Neighborhood neighborhood)`
    - Returns nothing
    - If there aren't any Houses, add the following three houses to the database __using a single C# statement__:
    ```
    new House { Address = "123 Fake Street", PostalCode = "T5B2C7" , Neighborhood = neighborhood },
    new House { Address = "555 Five Avenue", PostalCode = "T5C7Z1", Neighborhood = neighborhood },
    new House { Address = "888 Ate Boulevard", PostalCode = "T5Q5V4", Neighborhood = neighborhood }
    ```
4. `GetNeighborhoodAndHousesByName(ResidentialContext context, string name)`
    - returns a `Neighborhood` object
    - Return the neighborhood and all of its houses from the database based on the name provided
    - Return null if the neighborhood does not exist
5. `PrintNeighborhood(Neighborhood neighborhood)`
    - Returns nothing
    - Print the neighborhood details and all of the houses, if any.
    - If the neighborhood is null, print "No such neighborhood"
    Sample Output (with houses)
    ```
    -------------------
    Name: Garneau
    District: P
    Number of Houses: 3
    1. 123 Fake Street      T5B2C7
    2. 555 Five Avenue      T5C7Z1
    3. 888 Ate Boulevard    T5Q5V4
    -------------------
    ```

    Sample Output (without houses)
    ```
    -------------------
    Name: Garneau
    District: P
    Number of Houses: 0
    -------------------
    ```
    Sample Output (neighborhood is null)
    ```
    -------------------
    No such neighborhood
    -------------------
    ```
6. `GetHouseById(ResidentialContext context, int id)`
    - Return the `House` object with the specified id
    - Return `null` if there are no houses with that id.
7. `UpdateAddress(ResidentialContext context, int houseId, string newAddress)`
    - Returns nothing
    - Uses GetHouseById() to get the desired house
    - If the house is not null, update the address on the house to newAddress
8. `UpdateDistrict(ResidentialContext context, Neighborhood neighborhood, char newDistrict)`
    - Returns nothing
    - updates the provided neighborhood's district to the newDistrict
9. `RemoveHouseById(ResidentialContext context, int houseId)`
    - Returns nothing
    - Uses GetHouseById() to get the desired house
    - If the house is not null, remove the house from the database
10. `RemoveNeighborhood(ResidentialContext context, Neighborhood neighborhood)`
    - Returns nothing
    - If the neighborhood isn't null, remove it from the database.

The following is the output that should appear once you have completed the program. delete the .db before running
```
Created New Neighborhood
-------------------
Name: Garneau
District: P
Number of Houses: 0
-------------------
Added houses to Neighborhood
-------------------
Name: Garneau
District: P
Number of Houses: 3
1. 123 Fake Street      T5B2C7
2. 555 Five Avenue      T5C7Z1
3. 888 Ate Boulevard    T5Q5V4
-------------------
-------------------
Name: Garneau
District: G
Number of Houses: 3
1. 123 Fake Street      T5B2C7
2. 999 Pizza Place      T5C7Z1
3. 888 Ate Boulevard    T5Q5V4
-------------------
-------------------
Name: Garneau
District: G
Number of Houses: 2
2. 999 Pizza Place      T5C7Z1
3. 888 Ate Boulevard    T5Q5V4
-------------------
-------------------
No such neighborhood
-------------------
```