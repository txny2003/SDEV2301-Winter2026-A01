# Lesson 13 – Take-Home Practice (LINQ Basics with Pokémon)

## Goal
Practice the two core LINQ moves:
- `Where` (filter)
- `Select` (projection)
- chaining (`Where` → `Select`)
- predicting **result type and meaning**

✅ No menus. No user input. No extra program structure.  
✅ Just write queries and print results to verify.

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

## Tasks (Lesson 13 Scope)

### A. Filtering (`Where`)

1. All Pokémon with `Type1 == "Water"`
2. All Pokémon that are `IsLegendary == true`
3. All Pokémon with `Speed >= 90`
4. All Pokémon with `Total < 320`
5. All Pokémon that have a second type (`Type2 != null`)

### B. Projection (`Select`)

6. A sequence of **names only**
7. A sequence of **Dex numbers only**
8. A sequence of **Type1 values only**

### C. Filter + Project (Chaining)

9. Names of Pokémon with `Attack >= 120`
10. Names of Pokémon where `Type1 == "Dragon"`
11. Names + Speed (as a single string like `"Pikachu - 90"`) for Pokémon with `Speed >= 90`
12. Names of Pokémon that are **Water type** with `Total >= 500`

### D. "Read the Query" (Explain in plain English)

For each query below, write a sentence describing:

* what is filtered
* what is returned

```csharp
var q1 = pokedex.Where(p => p.Total >= 600);
var q2 = pokedex.Select(p => p.Type1);
var q3 = pokedex.Where(p => p.Type2 != null).Select(p => p.Name);
```

---

## Done Check (Self-check)

You’re done when you can confidently say:

* "This query returns `IEnumerable<Pokemon>` / `IEnumerable<string>` / `IEnumerable<int>`"
* and explain it without running it.

---
