using System.Collections.Generic;
using EnglishTrainer;
using NUnit.Framework;

namespace Sprint.Tests
{
    public class WordsPairs_Tests
    {
        [Test]
        public void GetNumberOfWordsPairs_5Pairs()
        {
            // arrange
            WordsPair wordsPair1 = new WordsPair("one", "один", true);
            WordsPair wordsPair2 = new WordsPair("two", "два", true);
            WordsPair wordsPair3 = new WordsPair("three", "три", true);
            WordsPair wordsPair4 = new WordsPair("four", "четыре", true);
            WordsPair wordsPair5 = new WordsPair("five", "пять", true);
            List<WordsPair> wordsPairsList = new List<WordsPair>();
            wordsPairsList.Add(wordsPair1);
            wordsPairsList.Add(wordsPair2);
            wordsPairsList.Add(wordsPair3);
            wordsPairsList.Add(wordsPair4);
            wordsPairsList.Add(wordsPair5);
            WordsPairs wordsPairs = new WordsPairs(wordsPairsList);
            // act
            int result = 5;
            // assert
            Assert.AreEqual(result, WordsPairs.GetNumberOfWordsPairs());
        }

        [Test]
        public void GetWordsPair_FirstPair()
        {
            // arrange
            var indexOfPair = 0;
            var wordsPairs = new WordsPairs(Input.GetWordsPairs());
            WordsPair expected = new WordsPair("one", "один", true);
            // act
            var result = WordsPairs.GetWordsPair(indexOfPair);
            // assert
            Assert.AreEqual(expected._englishWord, result._englishWord);
            Assert.AreEqual(expected._russianWord, result._russianWord);
        }
        
        [Test]
        public void GetRandomWordsPair_CorrectPair()
        {
            // arrange
            var wordsPairs = new WordsPairs(Input.GetWordsPairs());
            // act
            var result = WordsPairs.GetRandomWordsPair(true);
            // assert
            Assert.AreEqual(true, result.IsPairCorrect);
        }
        
        [Test]
        public void GetRandomWordsPair_IncorrectPair()
        {
            // arrange
            var wordsPairs = new WordsPairs(Input.GetWordsPairs());
            // act
            var result = WordsPairs.GetRandomWordsPair(false);
            // assert
            Assert.AreEqual(false, result.IsPairCorrect);
        }

        [Test]
        public void CreateWordsPairWithIndexes_CorrectPair()
        {
            // arrange
            WordsPairs wordsPairs = new WordsPairs(Input.GetWordsPairs());
            var englishWordIndex = 2;
            var russianWordIndex = 2;
            var isPairCorrect = true;
            WordsPair expected = new WordsPair("three", "три", true);
            // act
            var result = WordsPairs.CreateWordsPairWithIndexes(englishWordIndex, russianWordIndex, isPairCorrect);
            // assert
            Assert.AreEqual(expected._englishWord, result._englishWord);
            Assert.AreEqual(expected._russianWord, result._russianWord);
            Assert.AreEqual(expected.IsPairCorrect, result.IsPairCorrect);
        }
        
        [Test]
        public void CreateWordsPairWithIndexes_IncorrectPair()
        {
            // arrange
            WordsPairs wordsPairs = new WordsPairs(Input.GetWordsPairs());
            var englishWordIndex = 2;
            var russianWordIndex = 3;
            var isPairCorrect = false;
            WordsPair expected = new WordsPair("three", "четыре", false);
            // act
            var result = WordsPairs.CreateWordsPairWithIndexes(englishWordIndex, russianWordIndex, isPairCorrect);
            // assert
            Assert.AreEqual(expected._englishWord, result._englishWord);
            Assert.AreEqual(expected._russianWord, result._russianWord);
            Assert.AreEqual(expected.IsPairCorrect, result.IsPairCorrect);
        }

        [Test]
        public void GenerateWordsPairPossiblyRandom()
        {
            // arrange
            WordsPairs wordsPairs = new WordsPairs(Input.GetWordsPairs());
            // act
            var result = WordsPairs.GenerateWordsPairPossiblyRandom();
            // assert
            Assert.IsNotNull(result);
        }
    }
}