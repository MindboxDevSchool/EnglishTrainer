using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class SprintQuestion : Question
    {
        public const int NumberOfQuestions = 15;
        private bool IsTranslationCorrect { get; set; }
        public static bool RandomlyChooseToShowIncorrectTranslation()
        {
            Random random = new Random();
            int num = random.Next(0, 2);
            bool isCorrect = num == 1;
            return isCorrect;
        }

        public static string PickIncorrectTranslation(Dictionary<string, Word> dictionary, Word pickedWord)
        {
            Random random = new Random();
            Dictionary<string, Word> tempDictionary = dictionary;
            
            tempDictionary.Remove(pickedWord.GetWordVocable());
            Word wrongTranslationWord = tempDictionary.ElementAt(
                random.Next(0, tempDictionary.Count)).Value;
            
            return wrongTranslationWord.GetWordTranslation();
        }
        
        public string SetOptionalTranslationWord(Dictionary<string, Word> dictionary, Word word)
        {
            string optionalTranslationWord;
            
            this.IsTranslationCorrect = RandomlyChooseToShowIncorrectTranslation();
            if (!this.IsTranslationCorrect)
            {
                optionalTranslationWord = PickIncorrectTranslation(dictionary, word);
            }
            else
            {
                optionalTranslationWord = word.GetWordTranslation();
            }

            return optionalTranslationWord;
        }

        public static bool ValidateUserInput(bool isTranslationCorrect, bool userInputGuessed, Word word)
        {
            if (isTranslationCorrect && userInputGuessed)
            {
                return true;
            }
            else if (!isTranslationCorrect && !userInputGuessed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static QuestionResult SetQuestionResult(bool userAnswer, Word word, string translationOption)
        {
            QuestionResult questionResult;
            if (userAnswer && word.GetWordTranslation() == translationOption)
            {
                // User answered correctly
                questionResult = new QuestionResult(word, true);
                word.IncreaseTimesGuessedCorrectly();
            }
            else if (!userAnswer && word.GetWordTranslation() != translationOption)
            {
                // User answered correctly
                questionResult = new QuestionResult(word, true);
            }
            else
            {
                // User answered incorrectly
                questionResult = new QuestionResult(word, false);
            }
            
            return questionResult;
        }
    }
}