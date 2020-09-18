namespace EnglishTrainer
{
    public class Result
    {
        public Result(int numberOfCorrectAnswers, int numberOfWrongAnswers)
        {
            this.numberOfCorrectAnswers = numberOfCorrectAnswers;
            this.numberOfWrongAnswers = numberOfWrongAnswers;
        }

        public int numberOfCorrectAnswers { get; }
        public int numberOfWrongAnswers { get; }
    }
}