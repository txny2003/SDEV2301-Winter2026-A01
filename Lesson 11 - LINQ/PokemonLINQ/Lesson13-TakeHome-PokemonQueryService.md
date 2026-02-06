# Lesson 13 Take-Home Follow-Up: Pokémon Query Service + Unit Tests (Starter)

## Goal
Refactor your Lesson 13 Pokémon LINQ queries so they live inside a **service class** (methods that return results).
Then practice writing a few **xUnit tests** to verify those methods.

✅ You are NOT expected to finish every method.  
✅ The goal is to learn the workflow:
- write a method that returns data
- add null guards
- write tests that prove it works

---

## What You Will Build

A solution with **two projects**:

```

PokemonQuery/
├─ PokemonQuery.Domain/
│   ├─ Pokemon.cs
│   └─ PokemonQueryService.cs
├─ PokemonQuery.Tests/
│   └─ PokemonQueryServiceTests.cs
└─ PokemonQuery.slnx

```

> Tip: Create a new solution, add a **Class Library** (Domain) and an **xUnit Test Project** (Tests).  
> Add a Project Reference from Tests → Domain.

---

## Rules (Important)
- Service methods must be **pure** (no printing, no mutation).
- Methods must return results.
- Every method must guard against `null` input:
  - throw `ArgumentNullException`

Recommended pattern:

```csharp
ArgumentNullException.ThrowIfNull(pokedex);
```

---

## Step 1 — Domain Model + Dataset

Use the same Lesson 13 `Pokemon` class and dataset you used in the Lesson 13 Pokemon take-home.

Place `Pokemon.cs` in **PokemonQuery.Domain**.

> You can also create a `PokemonData` class (optional) to provide the dataset for tests.

Example optional helper:

```csharp
public static class PokemonData
{
    public static List<Pokemon> CreatePokedex() => new()
    {
        // paste your dataset here
    };
}
```

---

## Step 2 — Create the Service Class (Domain Project)

Create `PokemonQueryService.cs` with these starter methods.

### Level 1 (Do these first)

```csharp
public class PokemonQueryService
{
    public IEnumerable<Pokemon> GetWaterTypes(IEnumerable<Pokemon> pokedex)
    {
        ArgumentNullException.ThrowIfNull(pokedex);
        return pokedex.Where(p => p.Type1 == "Water");
    }

    public IEnumerable<string> GetNames(IEnumerable<Pokemon> pokedex)
    {
        ArgumentNullException.ThrowIfNull(pokedex);
        return pokedex.Select(p => p.Name);
    }

    // TODO: return names of Pokémon with Speed >= minSpeed
    public IEnumerable<string> GetFastPokemonNames(IEnumerable<Pokemon> pokedex, int minSpeed)
    {
        ArgumentNullException.ThrowIfNull(pokedex);
        throw new NotImplementedException();
    }
}
```

### Level 2 (Sorting + chaining)

```csharp
// TODO: Water Pokémon names sorted by Total descending
public IEnumerable<string> GetWaterNamesSortedByTotalDesc(IEnumerable<Pokemon> pokedex)
{
    ArgumentNullException.ThrowIfNull(pokedex);
    throw new NotImplementedException();
}

// TODO: Pokémon sorted by Total desc then Speed desc, returning "Name - Total - Speed"
public IEnumerable<string> GetSortedSummaryByTotalThenSpeed(IEnumerable<Pokemon> pokedex)
{
    ArgumentNullException.ThrowIfNull(pokedex);
    throw new NotImplementedException();
}
```

### Level 3 (Required grouping pattern)

Use the canonical pattern: `GroupBy` + `Select` + `Count()`.

```csharp
// Return (Type1, Count) for each Type1 present
public IEnumerable<(string Type1, int Count)> CountByType1(IEnumerable<Pokemon> pokedex)
{
    ArgumentNullException.ThrowIfNull(pokedex);
    throw new NotImplementedException();
}
```

---

## Step 3 — Starter Unit Tests (Tests Project)

Create `PokemonQueryServiceTests.cs`.

### Your job today:

Write tests for **at least 2 methods** (recommended: 1 filter + 1 grouping or sorting).

#### Test 1: Null guard (fast win)

```csharp
[Fact]
public void GetNames_NullPokedex_ThrowsArgumentNullException()
{
    var service = new PokemonQueryService();

    Assert.Throws<ArgumentNullException>(() => service.GetNames(null!));
}
```

#### Test 2: Filter correctness (water types)

```csharp
[Fact]
public void GetWaterTypes_ReturnsOnlyWaterType1()
{
    var pokedex = PokemonData.CreatePokedex();
    var service = new PokemonQueryService();

    var result = service.GetWaterTypes(pokedex).ToList();

    Assert.NotEmpty(result);
    Assert.All(result, p => Assert.Equal("Water", p.Type1));
}
```

#### Test 3 (Optional): Grouping counts by Type1

This test checks that the returned results contain expected counts.

```csharp
[Fact]
public void CountByType1_ReturnsExpectedCounts()
{
    var pokedex = PokemonData.CreatePokedex();
    var service = new PokemonQueryService();

    var result = service.CountByType1(pokedex).ToList();

    Assert.Contains(("Water", 4), result);
    Assert.Contains(("Normal", 4), result);
    Assert.Contains(("Dragon", 3), result);
    Assert.Contains(("Psychic", 3), result);
}
```

---

## What to Submit (Optional / Ungraded)

Submit one of these:

* A screenshot showing **2 passing tests**, OR
* A link to your repo with:

  * service class created
  * at least 2 methods implemented
  * at least 2 tests written

---

## Done Checklist (Success Criteria)

You are successful if you can say:

* "I moved my LINQ into a method that returns results."
* "My method throws `ArgumentNullException` on null input."
* "I wrote at least 2 tests that validate behavior."

---
