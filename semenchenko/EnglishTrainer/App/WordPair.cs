namespace EnglishTrainer.App
{
    public class WordPair
    {
        public string NativeLanguageWord { get; private set; }
        public string ForeignLanguageWord { get; private set; }
        public bool isLearned { get; private set; }
        private int timesMatched { get; set; }
        private bool isTranslated { get; set; }

        public WordPair(string nativeLanguageWord, string foreignLanguageWord)
        {
            this.NativeLanguageWord = nativeLanguageWord;
            this.ForeignLanguageWord = foreignLanguageWord;
            isLearned = false;
            timesMatched = 0;
            isTranslated = false;
        }

        public void MatchedCorrectly()
        {
            timesMatched++;
            AssertLearned();
        }

        public void TranslatedCorrectly()
        {
            isTranslated = true;
            AssertLearned();
        }

        private void AssertLearned()
        {
            isLearned = (timesMatched >= 3) || isTranslated;
        }
    }
}