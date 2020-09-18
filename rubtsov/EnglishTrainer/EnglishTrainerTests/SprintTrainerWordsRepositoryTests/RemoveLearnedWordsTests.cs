using System;
using System.Collections.Generic;
using System.IO;
using EnglishTrainer.Domain;
using NUnit.Framework;

namespace EnglishTrainerTests.SprintTrainerWordsRepositoryTests
{
    public class RemoveLearnedWordsTests
    {
        readonly string _pathToFileWithWords = 
            Directory
                .GetParent(Environment.CurrentDirectory)
                .Parent?.Parent?.Parent?.FullName + "\\EnglishTrainer\\TestData.csv";

        [Test]
        public void CorrectlyAnsweredFiveWords_FiveWordsLessLeftInWordsToTrain()
        {
            var correctlyAnsweredWords = new List<string> {"Black", "White", "Yellow", "Orange", "Scarlet"};
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 21);
            var expected = 16;
            
            wordsRepository.SelectWordsForTrainingSession();
            wordsRepository.RemoveLearnedWords(correctlyAnsweredWords);
            wordsRepository.SelectWordsForTrainingSession();
            
            Assert.AreEqual(wordsRepository.WordsToTrain.Count, expected);
        }
    }
}