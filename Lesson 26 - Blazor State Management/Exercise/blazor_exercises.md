# Cascading Values and Scoped Services Exercises

These exercises require you to work with cascading values across component trees and scoped services shared across pages. For each exercise, create the required components and service files, and update the NavMenu so that each page can be navigated to through the UI.

---

## Theme Selector (Cascading Values)

In this exercise you will build a simple UI where the user can select a colour theme in a parent component and have that theme automatically applied to a deeply nested child component — without the middle component knowing about it.

### Setup

1. Create a new class called `ThemeInfo` with the following properties:
    - `BackgroundColor`
        - `string`
        - Initialized to `"#FFFFFF"`
    - `TextColor`
        - `string`
        - Initialized to `"#000000"`

### Components

2. Create a new page called `ThemePage.razor`. This is the **parent** component.
3. Create a new component called `ThemePanel.razor`. This is the **child** component. It does **not** need the theme — it simply acts as a container.
4. Create a new component called `ThemePreview.razor`. This is the **grandchild** component. It will display a preview box using the cascaded theme.

### Parent — `ThemePage.razor`

5. In the `@code` block, declare a `ThemeInfo` variable called `theme` and initialize it to a `new ThemeInfo()`.
6. Add a heading to the page: `<h3>Theme Selector</h3>`
7. Add two input fields that allow the user to change the theme:
    - Background Color
        - A text input bound to `theme.BackgroundColor`
        - Label: "Background Color"
    - Text Color
        - A text input bound to `theme.TextColor`
        - Label: "Text Color"
8. Wrap the `<ThemePanel />` component in a `<CascadingValue>` component that passes the `theme` variable as the value.

### Child — `ThemePanel.razor`

9. Add a heading: `<h4>Theme Panel</h4>`
10. Add a short paragraph of placeholder text beneath the heading, for example: `<p>This component does not use the theme.</p>`
11. Render the `<ThemePreview />` component beneath the paragraph.
12. Do **not** declare a `[CascadingParameter]` in this component.

### Grandchild — `ThemePreview.razor`

13. Declare a `[CascadingParameter]` property of type `ThemeInfo` called `Theme`.
14. Add a `<div>` that uses the cascaded theme to style itself with an inline style:
    - `style="background-color: @Theme.BackgroundColor; color: @Theme.TextColor; padding: 1rem;"`
15. Inside the `<div>`, display the following text:
    - `<p>This is a preview of your selected theme.</p>`

### Expected Behaviour

When the user types a valid CSS colour (e.g. `#FF5733` or `lightblue`) into either input field on the parent page, the preview box in the grandchild component should update its colours in real time — without the middle `ThemePanel` component being involved at all.

---

## Quiz Tracker (Scoped Service)

In this exercise you will build a simple trivia quiz that persists the player's score across two pages using a scoped service. One page will present questions for the user to answer, and another page will display a summary of their results.

### Setup

1. Create a new class called `QuizState` in the `Services` folder with the following:
    - `int Score { get; private set; }` — initialized to `0`
    - `int TotalAnswered { get; private set; }` — initialized to `0`
    - A method `RecordAnswer(bool isCorrect)` that:
        - Always increments `TotalAnswered` by 1
        - Increments `Score` by 1 only if `isCorrect` is `true`
    - A method `Reset()` that sets both `Score` and `TotalAnswered` back to `0`
2. Register `QuizState` as a **scoped** service in `Program.cs`:
    - `builder.Services.AddScoped<QuizState>();`

### Pages

3. Create a new page called `Quiz.razor` at the route `/quiz`.
4. Create a new page called `QuizResults.razor` at the route `/quiz-results`.
5. Update the NavMenu so that both pages are accessible through the UI.

### Quiz Page — `Quiz.razor`

6. Inject `QuizState` into the page using the `@inject` directive.
7. Add the following list to the `@code` block:
    ```csharp
    private List<(string Question, string Answer)> questions = new()
    {
        ("What is the capital of France?", "Paris"),
        ("How many sides does a hexagon have?", "6"),
        ("What is the chemical symbol for water?", "H2O"),
        ("What planet is closest to the Sun?", "Mercury"),
        ("What is 12 x 12?", "144")
    };
    ```
8. Declare the following variables in the `@code` block:
    - `currentIndex` — `int`, initialized to `0`
    - `userAnswer` — `string?`, initialized to `null`
    - `feedback` — `string?`, initialized to `null`
9. Add a heading: `<h3>Quiz</h3>`
10. Display the current question using `questions[currentIndex].Question`.
11. Add a text input bound to `userAnswer`.
12. Add a button labelled "Submit Answer". When clicked, it should:
    - Compare `userAnswer` to `questions[currentIndex].Answer` (case-insensitive)
    - Call `Quiz.RecordAnswer(isCorrect)` on the injected service, passing the result of the comparison
    - Set `feedback` to `"Correct!"` or `"Incorrect. The answer was {questions[currentIndex].Answer}."` accordingly
    - Increment `currentIndex` by 1
    - Clear `userAnswer` back to `null`
13. Display `feedback` beneath the button.
14. Once all questions have been answered (`currentIndex >= questions.Count`), hide the question and input and instead display:
    - `<p>Quiz complete! Navigate to Results to see your score.</p>`

### Results Page — `QuizResults.razor`

15. Inject `QuizState` into the page using the `@inject` directive.
16. Add a heading: `<h3>Your Results</h3>`
17. If no questions have been answered (`Quiz.TotalAnswered == 0`), display:
    - `<p>You have not answered any questions yet.</p>`
18. Otherwise, display the following:
    - `<p>Score: @Quiz.Score / @Quiz.TotalAnswered</p>`
19. Add a button labelled "Reset Quiz". When clicked, it should call `Quiz.Reset()` on the service.

### Expected Behaviour

When the user answers questions on the Quiz page and then navigates to the Results page, their score and total answered should be preserved. Clicking Reset Quiz should clear the score, and navigating back to the Quiz page should allow the user to start again from question one.
