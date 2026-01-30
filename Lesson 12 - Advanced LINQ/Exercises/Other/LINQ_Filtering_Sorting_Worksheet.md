# LINQ Worksheet: Filtering, Sorting, and Projection

## Part A – Fill in the blanks

1. Use LINQ to filter a list of students whose grade is greater than 80:
```csharp
var highGrades = students.________(s => s.Grade > 80);
```

2. Project a list of book titles:
```csharp
var titles = books.________(b => b.Title);
```

3. Sort the list of prices in ascending order:
```csharp
var sorted = prices.________(p => p);
```

## Part B – Output Prediction

Given:
```csharp
var data = new[] { 3, 8, 1, 6 };
var result = data.Where(x => x > 5).OrderBy(x => x);
```

**Q: What will `result` contain?**  
A: `6, 8`
