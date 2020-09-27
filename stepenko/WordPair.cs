namespace EN_RUS_Trainer
{
    public class WordPair
    {
        public WordPair(string originalWord, string standardTranslation)
        {
            OriginalWord = originalWord;
            StandardTranslation = standardTranslation;
        }
        public string OriginalWord { get; }
        public string StandardTranslation { get; }
        public int NumberOfCorrectTranslations { get; set; }

        public void IncreaseNumberOfCorrectTranslations()
        {
            NumberOfCorrectTranslations++;
        }

        public void ResetNumberOfCorrectTranslations()
        {
          NumberOfCorrectTranslations = 0;
        }

        public bool CompareUserStandardTranslation(string userTranslation)
        {
            return StandardTranslation == userTranslation;
        }
    }
}