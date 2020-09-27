using System.Collections.Generic;

namespace EN_RUS_Trainer
{
    public class TranslationMode : LearningModes
    {
        protected override List<WordPair> GenerateTask()
        {
            return GetRandomWordsForAttempt(15);
        }

        protected override LearnAttemptResults CheckTask<T>(List<T> wordsForAttempt)
        {
            throw new System.NotImplementedException();
            //здесь должна быть реализация
        }
    }
}