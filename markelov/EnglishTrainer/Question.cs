using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class Question
    {
        private QuestionResult QuestionResult { get; set; }

        public Word GetRandomNotLearnedWord(Dictionary<string, Word> dictionary)
        {
            Random random = new Random();
            var matches = dictionary.Where(
                w => w.Value.GetWordIsLearnedStatus() != true);
            return matches.ElementAt(
                random.Next(0, dictionary.Count)).Value;
        }
        
        public static bool ValidateUserInput(string userInput, Word word)
        {
            if (userInput.Equals(word.GetWordTranslation(), 
                StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public QuestionResult SetQuestionResult(string userInput, Word word)
        {
            if (ValidateUserInput(userInput, word))
            {
                UpdateWord(word);
                QuestionResult = new QuestionResult(word, true);
            }
            else
            {
                QuestionResult = new QuestionResult(word, false);
            }
            return QuestionResult;
        }

        private static void UpdateWord(Word word)
        {
            word.IncreaseTimesGuessedCorrectly();
            if (word.GetTimesGuessedCorrectly() >= 3)
            {
                word.SetWordAsLearned();
            }
        }
    }
}