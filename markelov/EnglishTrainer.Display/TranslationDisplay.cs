using System;
using System.Collections.Generic;

namespace EnglishTrainer.Display
{
    public class TranslationDisplay : IDisplay
    {
        public void Display(Dictionary<string, Word> dictionary, Result result)
        {
            int numberOfQuestions = TranslationQuestion.NumberOfQuestions;
            for (int i = 0; i < numberOfQuestions; i++)
            {
                ShowQuestion(dictionary, result);
            }
            IDisplay resultDisplay = new ResultDisplay();
            resultDisplay.Display(dictionary, result);
        }
        public static void ShowQuestion(Dictionary<string, Word> dictionary, Result result)
        {
            TranslationQuestion translationQuestion = new TranslationQuestion();
            Word word = translationQuestion.GetRandomNotLearnedWord(dictionary);
            
            Console.WriteLine(word.GetWordVocable());
            string userAnswer = Console.ReadLine();
            QuestionResult questionResult = translationQuestion.SetQuestionResult(userAnswer, word);
            
            result.AppendResult(questionResult);
        }
    }
}