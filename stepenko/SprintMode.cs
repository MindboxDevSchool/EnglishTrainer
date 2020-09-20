using System;
using System.Collections.Generic;

namespace EN_RUS_Trainer
{
    public class SprintMode : LearningModes
    {
        protected List<String> GenerateRandomTranslations()
        {
            var randomWords = GetRandomWordsForAttempt(15);
            var randomTranslations = new List<String>();
            Random rnd = new Random();
            int randomIndex;

            for (int i = 0; i < randomWords.Count; i++)
            {
                if (rnd.Next(10) < 5)
                {
                    randomTranslations[i] = randomWords[i].StandardTranslation;
                }
                else
                {
                    randomIndex = rnd.Next(dictionary.Count);
                    randomTranslations[i] = dictionary[randomIndex].StandardTranslation;
                }
            }
            return randomTranslations;
        }

        protected override List<WordPair> GenerateTask()
        {
            throw new NotImplementedException();
            //здесь должна быть реализация
        }

        protected override LearnAttemptResults CheckTask<T>(List<T> wordsForAttempt)
        {
            throw new System.NotImplementedException();
            //здесь должна быть реализация
        }
    }
}