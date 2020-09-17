using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class DataServiceTests
    {
        [Test]
        public void LoadWordsFromFile_3WordsInFile_CorrectReading()
        {
            //arrange
            string pathToCSVTestFile = new DirectoryInfo(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName + "\\test files\\DataServiceTestData.csv";
            
            DataService dataService = new DataService();

            //act
            List<VocabularyWord> words = dataService.LoadWordsFromFile(pathToCSVTestFile);

            //assert
            Assert.AreEqual("red", words[1].Spelling);
            Assert.AreEqual("красный", words[1].Translation);
        }
    }
}