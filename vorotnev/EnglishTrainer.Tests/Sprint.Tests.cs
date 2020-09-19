using System.Collections.Generic;
using EnglishTrainer;
using NUnit.Framework;

namespace Sprint.Tests
{
    public class Sprint_Tests
    {
        [Test]
        public void CountUserResults_AllCorrectAnswers()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "пять", false);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "один", false);
            WordsPair[] generatedWordsPairs = new[] {wordsPair1, wordsPair2, wordsPair3, wordsPair4, wordsPair5};
            var userAnswersForSprintMode = new[] {false, true, true, true, false};
            // act
            var result = EnglishTrainer.Sprint.CountUserResults(generatedWordsPairs, userAnswersForSprintMode);
            // assert
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void CountUserResults_ThreeCorrectAnswers()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "пять", false);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "один", false);
            WordsPair[] generatedWordsPairs = new[] {wordsPair1, wordsPair2, wordsPair3, wordsPair4, wordsPair5};
            var userAnswersForSprintMode = new[] {true, false, true, true, false};
            // act
            var result = EnglishTrainer.Sprint.CountUserResults(generatedWordsPairs, userAnswersForSprintMode);
            // assert
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void CountUserResults_NoCorrectAnswers()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "пять", false);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "один", false);
            WordsPair[] generatedWordsPairs = new[] {wordsPair1, wordsPair2, wordsPair3, wordsPair4, wordsPair5};
            var userAnswersForSprintMode = new[] {true, false, false, false, true};
            // act
            var result = EnglishTrainer.Sprint.CountUserResults(generatedWordsPairs, userAnswersForSprintMode);
            // assert
            Assert.AreEqual(0, result);
        }
    }
}