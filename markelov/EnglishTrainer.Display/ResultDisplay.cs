using System;
using System.Collections.Generic;

namespace EnglishTrainer.Display
{
    public class ResultDisplay : IDisplay
    {
        public void Display(Dictionary<string, Word> dictionary, Result result)
        {
            Console.WriteLine("Your results are:");
            PrintResults(result);
            Dictionary<string, Word> updatedDictionary = Trainer.UpdateDictionaryWithResults(result);
            IDisplay menuDisplay = new MenuDisplay();
            menuDisplay.Display(updatedDictionary, result.CleanUpResult());
        }
        public static void PrintResults(Result result)
        {
            List<QuestionResult> questionResults = result.GetQuestionResults();
            foreach (QuestionResult questionResult in questionResults)
            {
                Console.WriteLine(questionResult.GetWordOutOfWordResult().GetWordVocable() + "| |" 
                    + questionResult.IsGuessedCorrectly + "| | Правильный ответ: "
                    + questionResult.GetWordOutOfWordResult().GetWordTranslation());
            }
            Console.WriteLine("Number of words guessed correctly: " + result.GetNumberOfWordsGuessedCorrectly());
            Console.WriteLine("Number of words guessed incorrectly: " + result.GetNumberOfWordsGuessedIncorrectly());
            Console.WriteLine("Press any key to try again:");
            Console.ReadKey();
        }
    }
}