# Lesson 17 Take-Home Practice: EF Core Trainer & Pokémon (One-to-Many + Migrations)

**Purpose:**
Practice EF Core **relationships** and **migrations** by building a small console app that stores Trainers and their Pokémon.

This builds directly on:

* Lesson 16: EF Core + SQLite basics
* Lesson 17: One-to-many + `.Include()` + migrations

---

## What You Are Practicing

* Creating related entities (one-to-many)
* Setting up `DbContext` and `DbSet<T>`
* Using EF Core **migrations** to create/update the database
* Inserting related data
* Loading related data with `.Include()`
* Understanding why `EnsureCreated()` is no longer enough

---

## Rules for This Exercise

* ✅ Use **EF Core migrations**
* ❌ Do **not** use `EnsureCreated()` for this exercise
* ❌ Do **not** delete the `.db` file as your workflow
* ❌ Do **not** write SQL
* ✅ Use `.Include()` when loading Pokémon for a trainer

---

## Scenario

You are building a simple Pokémon tracker.

* One **Trainer**
* Many **Pokémon**
* Each Pokémon belongs to exactly one Trainer

---

## Step 1: Create a Console Project

```bash
dotnet new console -n TrainerDex
cd TrainerDex
```

---

## Step 2: Install Required Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

> `Design` is needed for migrations.

---

## Step 3: Create the Models

Create a folder named `Models`.

### `Models/Trainer.cs`

```csharp
public class Trainer
{
    public int TrainerId { get; set; }
    public string Name { get; set; }

    // One trainer → many Pokémon
    public List<Pokemon> Pokemons { get; set; } = new();
}
```

### `Models/Pokemon.cs`

```csharp
public class Pokemon
{
    public int PokemonId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Level { get; set; }

    // Foreign key (required for the relationship)
    public int TrainerId { get; set; }

    // Navigation back to Trainer
    public Trainer Trainer { get; set; }
}
```

✅ Checkpoint:
You have defined a **one-to-many** relationship by using:

* `Trainer.Pokemons` (collection navigation)
* `Pokemon.TrainerId` (foreign key)
* `Pokemon.Trainer` (navigation back)

---

## Step 4: Create the DbContext

Create a folder named `Data`.

### `Data/AppDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Trainer> Trainers => Set<Trainer>();
    public DbSet<Pokemon> Pokemons => Set<Pokemon>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Force SQLite to use a single database file in the project root.
        // Prevents "no such table" errors caused by different working
        // directories between `dotnet run` and Visual Studio.
        var dbPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "trainerdex.db");
        dbPath = Path.GetFullPath(dbPath);

        options.UseSqlite($"Data Source={dbPath}");
    }
}
```

---

## Step 5: Create and Apply Your First Migration

### 5A) Install the EF CLI Tool (if you don’t already have it)

```bash
dotnet tool install --global dotnet-ef
```

### 5B) Create the Migration

```bash
dotnet ef migrations add InitialCreate
```

### 5C) Apply the Migration

```bash
dotnet ef database update
```

✅ Checkpoint:
You should now see:

* A `Migrations` folder created
* A `trainerdex.db` file created (usually in the project folder)

---

## Step 6: Insert One Trainer with Multiple Pokémon

Edit `Program.cs` to:

* Create a Trainer
* Add 2–3 Pokémon
* Save changes

### Example `Program.cs` starter

```csharp
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

// Seed only if no trainers exist (prevents duplicates when re-running)
if (!db.Trainers.Any())
{
    var trainer = new Trainer { Name = "Ash" };

    trainer.Pokemons.Add(new Pokemon { Name = "Pikachu", Type = "Electric", Level = 12 });
    trainer.Pokemons.Add(new Pokemon { Name = "Bulbasaur", Type = "Grass", Level = 11 });
    trainer.Pokemons.Add(new Pokemon { Name = "Charmander", Type = "Fire", Level = 10 });

    db.Trainers.Add(trainer);
    db.SaveChanges();
}
```

---

## Step 7: Display the Trainer and Their Pokémon Using `.Include()`

Still in `Program.cs`, query the trainer and print the roster.

```csharp
var trainerWithPokemons = db.Trainers
    .Include(t => t.Pokemons)
    .First();

Console.WriteLine($"Trainer: {trainerWithPokemons.Name}");
foreach (var p in trainerWithPokemons.Pokemons)
{
    Console.WriteLine($" - {p.Name} ({p.Type}) Lv{p.Level}");
}
```

✅ Checkpoint:
You should see output like:

```
Trainer: Ash
 - Pikachu (Electric) Lv12
 - Bulbasaur (Grass) Lv11
 - Charmander (Fire) Lv10
```

---

## Common Mistakes (and Fixes)

### “Pokemons is empty”

✅ You probably forgot `.Include()`.

```csharp
db.Trainers.Include(t => t.Pokemons)
```

---

### “no such table: Trainers” (SQLite Error)

✅ You likely forgot to run:

```bash
dotnet ef database update
```

or you changed models without creating a new migration.

---

## Optional Challenges (Not Required)

Try one (or more):

1. Add another Trainer with different Pokémon
2. Query and print all trainers and their Pokémon
3. Filter Pokémon by level (e.g., Level >= 11)
4. Sort Pokémon by level (descending)

---

## Reflection (Optional but Recommended)

Answer these in 2–3 sentences:

1. Why did we use **migrations** instead of `EnsureCreated()`?
2. Why was `.Include()` needed?
3. What does the foreign key `TrainerId` do?

---

## Key Takeaway

> Migrations let your database **evolve** safely over time,
> and navigation properties let you model relationships naturally in C#.

