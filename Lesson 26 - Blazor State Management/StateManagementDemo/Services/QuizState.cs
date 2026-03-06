namespace StateManagementDemo.Services
{
    public class QuizState
    {
        public int Score { get; private set; } = 0;
        public int TotalAnswered { get; private set; } = 0;

        public void RecordAnswer(bool isCorrect)
        {
            if (isCorrect)
                Score++;
            TotalAnswered++;
        }
        public void Reset()
        {
            Score = 0;
            TotalAnswered = 0;
        }
    }
}
