namespace EnglishTrainer.Contracts
{
    public class Result
    {
        public int NumberOfMistakes { get; }
        public int NumberOfCorrectAnswer { get; }
        public Result(int numberOfMistakes, int numberOfCorrectAnswer)
        {
            NumberOfMistakes = numberOfMistakes;
            NumberOfCorrectAnswer = numberOfCorrectAnswer;
        }
    }
}