using System;
using System.Collections.Generic;

namespace EnglishTrainer.Display
{
    public class SprintDisplay : IDisplay
    {
        public void Display(Dictionary<string, Word> dictionary, Result result)
        {
            int numberOfQuestions = SprintQuestion.NumberOfQuestions;
           
            for (int i = 0; i < numberOfQuestions; i++)
            {
                ShowQuestion(dictionary, result);
            }
            IDisplay resultDisplay = new ResultDisplay();
            resultDisplay.Display(dictionary, result);
        }
        public static void ShowQuestion(Dictionary<string, Word> dictionary, Result result)
        {
            SprintQuestion sprintQuestion = new SprintQuestion();
            Word word = sprintQuestion.GetRandomNotLearnedWord(dictionary);
            string translationOption = sprintQuestion.SetOptionalTranslationWord(dictionary, word);

            Console.WriteLine(word.GetWordVocable());
            Console.WriteLine(translationOption);
            Console.WriteLine("1. Correct");
            Console.WriteLine("2. Incorrect");

            bool userAnswer = GetUserInput(); 
            
            QuestionResult questionResult = SprintQuestion.SetQuestionResult(userAnswer, word, translationOption);
            
            result.AppendResult(questionResult);
        }

        public static bool GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput == "1";
        }
    }
}