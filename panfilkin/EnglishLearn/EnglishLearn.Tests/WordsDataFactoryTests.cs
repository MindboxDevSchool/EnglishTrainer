using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishLearn.Tests
{
    public class WordsDataFactoryTests
    {
        [Test]
        public void MakeWordsDataFromFile_ValidPath_WordsDataSuccessfulCreated()
        {
            // Arrange
            var wordsDataOriginal = new WordsData(new Dictionary<string, string>()
            {
                {"red", "красный"},
                {"green", "зеленый"},
                {"black", "черный"}
            });
            
            // Act
            var wordsData = WordsDataFactory.MakeWordsDataFromFile("test.csv");
            
            // Assert
            
            Assert.AreEqual(wordsDataOriginal._wordsData, wordsData._wordsData);
        }
        
        [Test]
        public void MakeWordsDataFromFile_InvalidPath_ThrowsException()
        {
            // Arrange
            // Act
            // Assert
            var exception = Assert.Throws<EnglishLearnException>(() =>
            {
                WordsDataFactory.MakeWordsDataFromFile("testttt.csv");
            });
            Assert.That(exception.Message == "Dictionary file not found!");
        }
        
        [Test]
        public void MakeWordsDataFromFile_BadCsvFile_ThrowsException()
        {
            // Arrange
            // Act
            // Assert
            var exception = Assert.Throws<EnglishLearnException>(() =>
            {
                WordsDataFactory.MakeWordsDataFromFile("testinvalid.csv");
            });
            Assert.That(exception.Message == "Bad words dictionary file!");
        }
    }
}