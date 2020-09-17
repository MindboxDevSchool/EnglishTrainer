using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class ResultTests
    {
        Result result = new Result(new List<QuestionResult>
        {
            { new QuestionResult(new Word("fly", "летать"), true)},
            { new QuestionResult(new Word("talk", "говорить"), false)},
            { new QuestionResult(new Word("swim", "плавать"), false)},
            { new QuestionResult(new Word("get", "получать"), false)}
        });

        [Test]
        public void GetNumberOfWordsGuessedCorrectly_GoodData()
        {
            int numberOfWordsGuessedCorrectly = result.GetNumberOfWordsGuessedCorrectly();
            Assert.AreEqual(1,numberOfWordsGuessedCorrectly);
        }
        
        [Test]
        public void GetNumberOfWordsGuessedIncorrectly_GoodData()
        {
            int numberOfWordsGuessedIncorrectly = result.GetNumberOfWordsGuessedIncorrectly();
            Assert.AreEqual(3,numberOfWordsGuessedIncorrectly);
        }
    }
}