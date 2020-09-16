namespace EnglishTrainer
{
    public class ExerciseResult
    {
        public int RightAnswersNumber { get; private set; }

        public int WrongAnswersNumber { get; private set; }

        public ExerciseResult(int rightAnswersNumber, int wrongAnswersNumber)
        {
            RightAnswersNumber = rightAnswersNumber;
            WrongAnswersNumber = wrongAnswersNumber;
        }
    }
}