namespace EnglishTrainer
{
    public class QuestionResult
    {
        public bool IsGuessedCorrectly { get; set; }
        private Word Word { get; set; }

        public QuestionResult(Word word, bool isGuessedCorrectly)
        {
            this.IsGuessedCorrectly = isGuessedCorrectly;
            this.Word = word;
        }

        public Word GetWordOutOfWordResult()
        {
            return this.Word;
        }
    }
}