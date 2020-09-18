using System;
using System.IO;
using EnglishTrainer.Infrastructure;
using NUnit.Framework;

namespace EnglishTrainerTests
{
    public class CsvDataLoaderTests
    {
        private readonly string _pathToNonExistentFile = string.Empty;
        readonly string _pathToFileWithWords = 
            Directory
                .GetParent(Environment.CurrentDirectory)
                .Parent?.Parent?.Parent?.FullName + "\\EnglishTrainer\\TestData.csv";
        
        [Test] public void FileNotFound_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                var csvWordsLoader = new CsvWordsLoader(_pathToNonExistentFile);
            });
        }
        
        [Test] public void TestDataCsvFileLoaded_AllWordsLoaded()
        {
            IWordsLoader wordsLoader = new CsvWordsLoader(_pathToFileWithWords);
            var expected = 21; 
            
            var words = wordsLoader.LoadWords;
            
            Assert.AreEqual(words.Count, expected);
        }
    }
}