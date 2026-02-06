# Lesson 14 – Take-Home Practice (Sorting, Projection, Grouping with Pokémon)

## Goal
Practice:
- Sorting: `OrderBy`, `OrderByDescending`, `ThenBy`
- Projection: `Select` (including shaping results)
- Grouping: `GroupBy` + `Count()` (required pattern)
- Reading query order + result shape

✅ No menus. No user input.  
✅ Just queries + printing.

Use the same `Pokemon` class and `pokedex` dataset from Lesson 13.

---

## Starter Dataset

Create this model:

```csharp
public class Pokemon
{
    public int Dex { get; }
    public string Name { get; }
    public string Type1 { get; }
    public string? Type2 { get; }
    public int Attack { get; }
    public int Defense { get; }
    public int Speed { get; }
    public int Total { get; }
    public bool IsLegendary { get; }

    public Pokemon(int dex, string name, string type1, string? type2,
        int attack, int defense, int speed, int total, bool isLegendary)
    {
        Dex = dex;
        Name = name;
        Type1 = type1;
        Type2 = type2;
        Attack = attack;
        Defense = defense;
        Speed = speed;
        Total = total;
        IsLegendary = isLegendary;
    }
}
```

Create this list:

```csharp
var pokedex = new List<Pokemon>
{
    new(  1, "Bulbasaur",  "Grass",  "Poison", 49, 49, 45, 318, false),
    new(  4, "Charmander", "Fire",   null,     52, 43, 65, 309, false),
    new(  7, "Squirtle",   "Water",  null,     48, 65, 43, 314, false),
    new( 25, "Pikachu",    "Electric",null,    55, 40, 90, 320, false),
    new( 39, "Jigglypuff", "Normal", "Fairy",  45, 20, 20, 270, false),
    new( 52, "Meowth",     "Normal", null,     45, 35, 90, 290, false),
    new( 63, "Abra",       "Psychic",null,     20, 15, 90, 310, false),
    new( 92, "Gastly",     "Ghost",  "Poison", 35, 30, 80, 310, false),
    new( 95, "Onix",       "Rock",   "Ground", 45,160, 70, 385, false),
    new(129, "Magikarp",   "Water",  null,     10, 55, 80, 200, false),
    new(131, "Lapras",     "Water",  "Ice",    85, 80, 60, 535, false),
    new(133, "Eevee",      "Normal", null,     55, 50, 55, 325, false),
    new(143, "Snorlax",    "Normal", null,    110, 65, 30, 540, false),
    new(149, "Dragonite",  "Dragon", "Flying",134, 95, 80, 600, false),
    new(150, "Mewtwo",     "Psychic",null,    110, 90,130, 680, true),
    new(151, "Mew",        "Psychic",null,    100,100,100, 600, true),
    new(245, "Suicune",    "Water",  null,     75,115, 85, 580, true),
    new(248, "Tyranitar",  "Rock",   "Dark",  134,110, 61, 600, false),
    new(384, "Rayquaza",   "Dragon", "Flying",150, 90, 95, 680, true),
    new(445, "Garchomp",   "Dragon", "Ground",130, 95,102, 600, false),
};
```

---

## Instructions

For each task:

1. Write a LINQ query (no loops to build results)
2. Print the results to verify
3. Write a 1-line comment: **What type does this query return?**

---

## Tasks (Lesson 14 Scope)

### A. Sorting (Single Key)
1. Pokémon sorted by **Speed ascending** (print Name + Speed)
2. Pokémon sorted by **Attack descending** (print Name + Attack)
3. Pokémon sorted by **Total descending** (print Name + Total)

### B. Sorting (Primary + Secondary with `ThenBy`)
4. Sort by `Type1` ascending, then by `Name` ascending (print Type1 + Name)
5. Sort by `Total` descending, then by `Speed` descending (print Name + Total + Speed)

### C. Filter → Sort → Project Chains
6. Names of **Water** Pokémon sorted by `Total` descending
7. Names of Pokémon with `Speed >= 90` sorted by `Speed` descending, then by `Name`
8. Legendary Pokémon sorted by `Total` descending, projecting **Name and Total only**
9. Dragon Pokémon (`Type1 == "Dragon"`) sorted by `Attack` descending, projecting `"Name (Attack)"`

### D. Projection Variations (Shape Matters)
10. Project to an anonymous type with:
   - `Name`
   - `IsFast` (Speed >= 90)

```csharp
var fastFlag = pokedex.Select(p => new { p.Name, IsFast = p.Speed >= 90 });
```

Print: `Name` and `IsFast`.

11. Project to a “pair” string format:

* `"Type1: Name"`

### E. Grouping + Counting (Required Pattern)

Use **this exact pattern** for grouping tasks:

```csharp
var counts =
    pokedex
        .GroupBy(p => p.Type1)
        .Select(g => new { Key = g.Key, Count = g.Count() });
```

12. Count Pokémon by `Type1` (print `Type1: Count`)
13. Count Pokémon by `IsLegendary` (print `Legendary? True/False: Count`)
14. Count Pokémon by “SpeedBucket”:

* `"Slow"` if Speed < 60
* `"Medium"` if Speed is 60–89
* `"Fast"` if Speed >= 90

Hint:

```csharp
var speedBuckets =
    pokedex
        .GroupBy(p =>
            p.Speed >= 90 ? "Fast" :
            p.Speed >= 60 ? "Medium" : "Slow")
        .Select(g => new { Bucket = g.Key, Count = g.Count() });
```

### F. Stretch (Optional)

15. Filter to only Pokémon with `Total >= 500`, then group by `Type1`, then count.

---

## Done Check (Self-check)

You’re done when you can explain for any query:

* What is filtered?
* How is it sorted?
* What is returned (type + meaning)?
* If grouped: what is the group Key and what does Count represent?

---
