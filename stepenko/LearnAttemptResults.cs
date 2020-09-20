using System.Collections.Generic;

namespace EN_RUS_Trainer
{
    public class LearnAttemptResults
    {
        public List<WordPair> CorrectlyTranslatedWordsDuringAttempt;
        public List<WordPair> IncorrectlyTranslatedWordsDuringAttempt;
        
        private int numberOfCorrectTranslations;
        public int NumberOfCorrectTranslationsDuringAttempt
        {
            get { return numberOfCorrectTranslations; }
            set { numberOfCorrectTranslations = CorrectlyTranslatedWordsDuringAttempt.Count; }
        }


        private int numberOfIncorrectTranslations;
        public int NumberOfIncorrectTranslationsDuringAttempt
        {
            get
            { return numberOfIncorrectTranslations; }
            set
            { numberOfIncorrectTranslations = IncorrectlyTranslatedWordsDuringAttempt.Count; }
        }

        public void AddWordPairToCorrectlyTranslatedOnes(WordPair wordPair)
        {
            CorrectlyTranslatedWordsDuringAttempt.Add(wordPair);
        }
        
        public void AddWordPairToIncorrectlyTranslatedOnes(WordPair wordPair)
        {
            IncorrectlyTranslatedWordsDuringAttempt.Add(wordPair);
        }

        public void DeleteFromIncorrectlyTranslatedOnes(WordPair wordPair)
        {
            IncorrectlyTranslatedWordsDuringAttempt.Remove(wordPair);
        }
        
    }
}