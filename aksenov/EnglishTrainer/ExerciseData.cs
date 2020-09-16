namespace EnglishTrainer
{
    public abstract class ExerciseData
    {
        public string Words { get; private set; }
        
        public int Count { get; private set; }

        protected ExerciseData(string words)
        {
            Words = words;
        }
    }
}