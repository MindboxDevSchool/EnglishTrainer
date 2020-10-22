using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishLearn.Tests
{
    public class WordsDataTests
    {
        private Dictionary<string, string> _wordsDataOriginal;

        [SetUp]
        public void Setup()
        {
            _wordsDataOriginal = new Dictionary<string, string>()
            {
                {"red", "красный"},
                {"green", "зеленый"},
                {"black", "черный"}
            };
        }
        
        [Test]
        public void WordsDataConstructor_ValidWordsData_SuccessInitialized()
        {
            // Arrange
            // Act
            var wordsData = new WordsData(_wordsDataOriginal);
            // Assert
            Assert.AreEqual(_wordsDataOriginal, wordsData._wordsData);
        }
        
        [Test]
        public void WordsDataConstructor_EmptyWordsData_ThrowsException()
        {
            // Arrange
            // Act
            // Assert
            
            var exception = Assert.Throws<EnglishLearnException>(() =>
            {
                new WordsData(new Dictionary<string, string>());
            });
            Assert.That(exception.Message == "Word dictionary is empty!");
        }
        
        [Test]
        public void GetEnglishTranslateOfRussianWord_ExistedWord_SuccessTranslated()
        {
            // Arrange
            var russianWordOriginal = "красный";
            var englishWordOriginal = "red";
            var wordsData = new WordsData(_wordsDataOriginal);
            // Act
            var englishWord = wordsData.GetEnglishTranslateOfRussianWord(russianWordOriginal);
            // Assert
            Assert.AreEqual(englishWordOriginal, englishWord);
        }
        
        [Test]
        public void GetEnglishTranslateOfRussianWord_UnknownWord_ThrowsException()
        {
            // Arrange
            var russianWordOriginal = "Sovent";
            var wordsData = new WordsData(_wordsDataOriginal);
            // Act
            // Assert
            var exception = Assert.Throws<EnglishLearnException>(() =>
            {
                wordsData.GetEnglishTranslateOfRussianWord(russianWordOriginal);
            });
            Assert.That(exception.Message == "Word 'Sovent' not found in dictionary words!");
        }

        [Test]
        public void GetRandomWordPair_NoData_WordPairIsExistInDictionary()
        {
            // Arrange
            var wordsData = new WordsData(_wordsDataOriginal);
            // Act
            var wordPair = wordsData.GetRandomWordPair();
            // Assert
            Assert.True(wordsData.GetWordsData().ContainsKey(wordPair.Key));
        }
    }
}