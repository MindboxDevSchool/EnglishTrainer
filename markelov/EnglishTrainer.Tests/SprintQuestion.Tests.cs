using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class SprintQuestionTests
    {
        Dictionary<string, Word> dictionary = new Dictionary<string, Word>
            {
                { "fly", new Word("fly", "летать") },
                { "walk", new Word("walk", "идти") },
                { "talk", new Word("talk", "говорить") }
            };


        [Test]
        public void PickIncorrectTranslation_DictionaryWithThreeValues()
        {
            Word pickedWord = dictionary["talk"];
            string assertedTranslationString = pickedWord.GetWordTranslation();
           
            string incorrectTranslationOption = SprintQuestion.PickIncorrectTranslation(dictionary, pickedWord);

            Assert.AreNotEqual(assertedTranslationString,incorrectTranslationOption);
        }
        
        [Test]
        public void ValidateUserInput_UserPicksFalseWhenTranslationIsWrong()
        {
            Word pickedWord = new Word("fly", "летать");
            bool isTranslationCorrect = false;
            bool userInputGuessed = false;
            
            bool isGuessedRight = SprintQuestion.ValidateUserInput(isTranslationCorrect, 
                userInputGuessed, pickedWord);
            
            Assert.AreEqual(true,isGuessedRight);
        }
        
        [Test]
        public void SetQuestionResult_UserPicksRightAnswer()
        {
            Word pickedWord = new Word("fly", "летать");
            bool userAnswer = true;
            string tranlationOptionString = "летать";
            
            QuestionResult questionResult  = SprintQuestion.SetQuestionResult(userAnswer, 
                pickedWord, tranlationOptionString);
            
            Assert.IsTrue(questionResult.IsGuessedCorrectly);
            Assert.AreEqual(1, questionResult.GetWordOutOfWordResult().GetTimesGuessedCorrectly());
        }
    }
}