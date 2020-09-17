using System;

namespace EnglishTrainer
{
    public class Word
    {
        private string WordVocable { get; set; }
        private string WordTranslation { get; set; }
        private int TimesGuessedCorrectly { get; set; }
        private bool IsLearned { get; set; }

        public Word(string vocable, string translation)
        {
            this.WordVocable = vocable;
            this.WordTranslation = translation;
            this.TimesGuessedCorrectly = 0;
            this.IsLearned = false;
        }

        public string GetWordVocable()
        {
            return this.WordVocable;
        }
        
        public string GetWordTranslation()
        {
            return this.WordTranslation;
        }

        public int GetTimesGuessedCorrectly()
        {
            return this.TimesGuessedCorrectly;
        }
        
        public void IncreaseTimesGuessedCorrectly()
        {
            this.TimesGuessedCorrectly++;
        }

        public bool GetWordIsLearnedStatus()
        {
            return this.IsLearned;
        }
        
        public void SetWordAsLearned()
        {
            this.IsLearned = true;
        }
    }
}