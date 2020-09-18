using System;
using System.IO;
using EnglishTrainer.Domain;
using NUnit.Framework;

namespace EnglishTrainerTests.SprintTrainerWordsRepositoryTests
{
    public class SelectWordsForTrainingSessionTests
    {
        readonly string _pathToFileWithWords = 
            Directory
                .GetParent(Environment.CurrentDirectory)
                .Parent?.Parent?.Parent?.FullName + "\\EnglishTrainer\\TestData.csv";

        [Test]
        public void NoWordsInRepository_NoWordsToTrain()
        {
            string pathToEmptyFile = 
                Directory
                    .GetParent(Environment.CurrentDirectory)
                    .Parent?.Parent?.Parent?.FullName + "\\EnglishTrainer\\EmptyFile.csv";
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(pathToEmptyFile, 15);
            var expected = 0;
            
            wordsRepository.SelectWordsForTrainingSession();
            
            Assert.AreEqual(wordsRepository.WordsToTrain.Count, expected);
        }

        [Test]
        public void ZeroWordsPerTraining_NoWordsToTrain()
        {
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 0);
            var expected = 0;
            
            wordsRepository.SelectWordsForTrainingSession();
            
            Assert.AreEqual(wordsRepository.WordsToTrain.Count, expected);
        }
        
        [Test]
        public void WordsPerTrainingValueLessThanWordsInRepository_WordsToTrainQuantityEqualsWordsPerTrainingValue()
        {
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 10);
            var expected = 10;
            
            wordsRepository.SelectWordsForTrainingSession();
            
            Assert.AreEqual(wordsRepository.WordsToTrain.Count, expected);
        }
        
        [Test]
        public void WordsPerTrainingValueGreaterThanWordsInRepository_WordsToTrainQuantityEqualsWordsInRepositoryQty()
        {
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 30);
            var expected = 21;
            
            wordsRepository.SelectWordsForTrainingSession();
            
            Assert.AreEqual(wordsRepository.WordsToTrain.Count, expected);
        }
        
        [Test]
        public void WordsPerTrainingValueEqualsWordsInRepositoryQuantity_WordsToTrainQuantityEqualWordsInRepository()
        {
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 21);
            var expected = 21;
            
            wordsRepository.SelectWordsForTrainingSession();
            
            Assert.AreEqual(wordsRepository.WordsToTrain.Count, expected);
        }
    }
}