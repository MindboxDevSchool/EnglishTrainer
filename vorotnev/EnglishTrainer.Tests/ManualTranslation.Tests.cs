using EnglishTrainer;
using NUnit.Framework;

namespace Sprint.Tests
{
    public class ManualTranslation_Tests
    {
        [Test]
        public void CountUserResults_AllCorrectAnswers()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "один", true);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "пять", true);
            WordsPair[] generatedWordsPairs = new[] {wordsPair1, wordsPair2, wordsPair3, wordsPair4, wordsPair5};
            var userAnswersForManualTranslationMode = new[] {"один", "два", "три", "четыре", "пять"};
            // act
            var result = ManualTranslation.CountUserResults(generatedWordsPairs, userAnswersForManualTranslationMode);
            // assert
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void CountUserResults_ThreeCorrectAnswers()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "один", true);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "пять", true);
            WordsPair[] generatedWordsPairs = new[] {wordsPair1, wordsPair2, wordsPair3, wordsPair4, wordsPair5};
            var userAnswersForManualTranslationMode = new[] {"один", "десять", "три", "шестнадцать", "пять"};
            // act
            var result = ManualTranslation.CountUserResults(generatedWordsPairs, userAnswersForManualTranslationMode);
            // assert
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void CountUserResults_NoCorrectAnswers()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "один", true);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "пять", true);
            WordsPair[] generatedWordsPairs = new[] {wordsPair1, wordsPair2, wordsPair3, wordsPair4, wordsPair5};
            var userAnswersForManualTranslationMode = new[] {"ноль", "десять", "не знаю", "шестнадцать", "5"};
            // act
            var result = ManualTranslation.CountUserResults(generatedWordsPairs, userAnswersForManualTranslationMode);
            // assert
            Assert.AreEqual(0, result);
        }
    }
}