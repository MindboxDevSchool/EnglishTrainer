using System;
using System.Collections.Generic;

namespace EN_RUS_Trainer
{
    public abstract class LearningModes
    {
        public static List<WordPair> dictionary = Dictionary.DictionaryForLearning;

        public static List<WordPair> GetRandomWordsForAttempt(int amountOfWords)
        {
            Random rnd = new Random();
            int newRandomId;
            var wordsForAttempt = new List<WordPair>();

            while (wordsForAttempt.Count < amountOfWords)
            {
                newRandomId = rnd.Next(dictionary.Count);
                if (dictionary[newRandomId].NumberOfCorrectTranslations < 3)
                {
                    wordsForAttempt.Add(dictionary[newRandomId]);
                }
                else
                {
                    dictionary.Remove(dictionary[newRandomId]);
                }
            }
            return wordsForAttempt;
        }
        
        protected abstract List<WordPair> GenerateTask();

        protected abstract LearnAttemptResults CheckTask<T>(List<T> wordsForAttempt);

    }
}