# EfCore with Blazor Exercise

This exercise will add functionality to the existing `TaskItem` and `Poll` models from Lesson 22 - Forms and Data Binding lesson. 

Before starting, copy the `TaskItem` and `Poll` models from Lesson 22 into a new Blazor project.

## Database Setup

1. Create a new DbContext class that includes a DbSet<TaskItem> and DbSet<Poll> properties.
2. Register the DbContext with the services in `Program.cs`.
3. Migrate the models to the database using the CLI and the `dotnet` tools.

## Services
1. Create a `TaskService` class with the following structure:
    - private readonly field for the DbContext class.
    - Constructor that accepts a database context and assigns it to the private field.
    - `ListTasksAsync()`
        - Method that returns a `Task<List<TaskItem>>`
        - asynchronously calls the ToListAsync() method on the Tasks collection in the database and returns it.
    - `AddTaskAsync(TaskItem t)`
        - Returns `Task<TaskItem>`
        - Throws an exception if the parameter is null.
        - Asynchronously adds a new `TaskItem` to the database.
    - `UpdateTaskAsync(TaskItem taskItem)`
        - Returns `Task<TaskItem>`
        - Throws an exception if the parameter is null.
        - Asynchronously updates the `TaskItem` to the database.
    - `DeleteTaskAsync(int id)`
        - Void method (returns `Task`)
        - Asynchronously finds the task in the database
        - if the TaskItem is not found throw a `KeytNotFoundException`
        - Removes the specified task item from the database
2. Create a `PollService` class with the following structure:
    - private readonly field for the `IDbContextFactory<AppDbContext>` class.
    - Constructor that accepts a `IDbContextFactory<AppDbContext>` context and assigns it to the private field.
    - `ListPollsAsync()`
        - Method that returns a `Task<List<Poll>>`
        - asynchronously calls the ToListAsync() method on the Polls collection in the database and returns it.
    - `AddPollAsync(Poll p)`
        - Method that returns `Task<Poll>`
        - Throws an exception if the parameter is null.
        - Asynchronously adds a new `Poll` to the database.
    - `GetVoteCounts()`
        - Async Method that returns a `Task<List<(string? Candidate, int Votes)>>`
        - Uses LINQ to get the number of votes that each candidate has and returns the new data set. (Hint: Use GroupBy)
        - The results should be ordered by the vote count in descending order, and then by the candidate in ascending order.

3. Register the `TaskService` and `PollService` as __scoped__ services in `Program.cs`.

## PollForm Page

1. Create a new `PollForm.razor` page with the following starting code:
```
@page "/pollform"
@using ProjectName.Models

<EditForm Model="newPoll">
    <ValidationSummary />
    <DataAnnotationsValidator />

    <label>Name:</label>
    <InputText @bind-Value="newPoll.Name" />
    <ValidationMessage For="@(() => newPoll.Name)" />
    <br />
    <label>City:</label>
    <InputText @bind-Value="newPoll.City" />
    <ValidationMessage For="@(() => newPoll.City)" />
    <br />
    <InputRadioGroup @bind-Value="@newPoll.Candidate">
        Candidate:
        <br>
        @foreach (var candidate in Candidates)
        {
            <InputRadio Value="candidate" />
            @candidate
            <br>
        }
    </InputRadioGroup>
    <ValidationMessage For="@(() => newPoll.Candidate)" />
    <br />
    <label>Confidence Level:</label>
    <InputNumber @bind-Value="newPoll.ConfidenceLevel" />
    <ValidationMessage For="@(() => newPoll.ConfidenceLevel)" />
    <br />
    <button type="submit">Submit</button>
</EditForm>

@code {
    private Poll newPoll = new();
    
    private List<string> Candidates = new List<string>
    {
        "Dancing Dan",
        "Roller Blading Guitar Guy",
        "The Current Mayor",
        "A rock with googley eyes glued to it"
    };
}
```
2. Add a new `List<(string? Candidate, int Votes)>` to the `@code` block.
3. Override `OnInitializesAsync()` to load the Vote counts from the database when the page loads.
4. Add a method called AddPoll():
    - Adds a new poll to the database
    - Reloads the vote counts
    - Resets the Poll form
5. In the HTML, add the following logic:
    - If the `List<(string? Candidate, int Votes)>` is null, show "Loading..."
    - If there are no entries in the database,, show "no results"
    - If there are values in the database, display a table that shows each candidate and the number of votes they have.

## TaskItems Page

1. Create a new `TaskItems.razor` page with the following starting code:

```
@page "/taskform"
@using EfCoreBlazorDemo.Models
<EditForm Model="_model">
    <ValidationSummary />
    <DataAnnotationsValidator />

    <label>Title:</label>
    <InputText @bind-Value="_model.Title" />
    <ValidationMessage For="@(() => _model.Title)" />
    <br />
    <label>Due Date:</label>
    <InputDate @bind-Value="_model.DueDate" />
    <ValidationMessage For="@(() => _model.DueDate)" />
    <br />
    <label>Is Complete:</label>
    <InputCheckbox @bind-Value="_model.IsComplete" />
    <ValidationMessage For="@(() => _model.IsComplete)" />
    <br />
    <button type="submit">Submit</button>
</EditForm>

@code {
    private List<TaskItem>? tasks;
    private TaskItem _model = new();
}
```
2. Override `OnInitializesAsync()` to load the TaskItem data from the database when the page loads.
3. Add the following methods:
    - `SaveAsync()`
        - Async void (returns the `Task` data type)
        - if the user is editing a task, will update the task with the changes
        - If the user is adding a new task, it will add the new task to the database
        - Resets the form and the edit mode after finishing
    - `EditTask(TaskItem task)`
        - void
        - Loads the provided `task` parameter into the form and enables edit mode.
    - `DeleteTaskAsync(int id)`
        - Async void (returns the `Task` data type)
        - Asks the user if they want to delete the task (calls the browser "confirm" dialog)
        - If the user says no, exit the method.
        - If the user says yes, then delete the task.
        - If the task was currently being edited, reset the form to the original mode.
    - `ResetForm()`
        - Clears the fields in the form.
        - Exits "edit mode"
4. In the HTML, add the following logic:
    - If the `List<(string? Candidate, int Votes)>` is null, show "Loading..."
    - If there are no entries in the database,, show "no results"
    - If there are values in the database, display a table that:
        - Displays Title
        - Displays DueDate
        - Display "Yes" if the task is complete, "No" if the task is incomplete.
        - Each row should have two buttons:
            - Edit (allows the user to edit the task)
            - Delete (Allows the user to delete the task)
        - When the user is editing a task, an <h4> above the form should show "Edit Task", otherwise it must say "Add Task"
        - When the user is editing a task, a button must appear at the bottom of the form that says "Cancel" which will allow the user to stop edit mode.