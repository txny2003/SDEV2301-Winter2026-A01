# Initial Setup for a Blazor App with EfCore and Sqlite

1. Install the required NuGet packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
2. Create the required Models.
3. Add the `DbContext` class. Include `DbSet` collections for each model required in the database.
4. Register the `DbContext` class with the services in `Program.cs`. For example:
```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
```
5. Create the required Service classes (remember to use async methods only for database operations).
6. Register the services in `Program.cs`.

## Create/Migrate the database:

- Using the following code, temporarily create a scope for the DbContext __after__ the `var app = builder.Build();` line to ensure creation of the database :
    ```
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
    }
    ```
- Run the program to create the database
