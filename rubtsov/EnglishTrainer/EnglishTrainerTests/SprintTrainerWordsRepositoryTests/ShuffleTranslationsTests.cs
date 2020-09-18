using System;
using System.IO;
using System.Linq;
using EnglishTrainer.Domain;
using NUnit.Framework;

namespace EnglishTrainerTests.SprintTrainerWordsRepositoryTests
{
    public class ShuffleTranslationsTests
    {
        readonly string _pathToFileWithWords = 
            Directory
                .GetParent(Environment.CurrentDirectory)
                .Parent?.Parent?.Parent?.FullName + "\\EnglishTrainer\\TestData.csv";

        [Test] public void MoreThanFourWordsPerTraining_ShuffledTranslationsSequenceAreNotEqualWordsToTrainTranslationsSequence()
        {
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 15);
            wordsRepository.SelectWordsForTrainingSession();
            wordsRepository.ShuffleTranslations();
            
            var sequenceEqual = wordsRepository.WordsToTrain.Values.ToList().SequenceEqual(wordsRepository.ShuffledWordTranslations);
            
            Assert.True(!sequenceEqual);
        }
        
        [Test] public void OneWordPerTraining_ShuffledTranslationWordAreEqualWordsToTrainTranslationWord()
        {
            IWordsRepository wordsRepository = new SprintTrainerWordsRepository(_pathToFileWithWords, 1);
            wordsRepository.SelectWordsForTrainingSession();
            wordsRepository.ShuffleTranslations();
            
            var sequenceEqual = wordsRepository.WordsToTrain.Values.ToList().SequenceEqual(wordsRepository.ShuffledWordTranslations);
            
            Assert.True(sequenceEqual);
        }
    }
}