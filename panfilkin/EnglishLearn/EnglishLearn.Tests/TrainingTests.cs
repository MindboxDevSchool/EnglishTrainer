using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishLearn.Tests
{
    public class TrainingTests
    {
        [Test]
        public void SprintTrainingConstructor_StandartData_WordsToCheckCountAreEquals15()
        {
            // Arrange
            
            // Act
            var sprintTraining = new SprintTraining(new WordsData(new Dictionary<string, string>()
            {
                {"black", "черный"},
                {"red", "красный"}
            }));
            // Assert
            Assert.AreEqual(sprintTraining.CountOfWordsToCheck, 15);
        }
        
        [Test]
        public void TranslatorTrainingConstructor_StandartData_WordsToCheckCountAreEquals10()
        {
            // Arrange
            
            // Act
            var sprintTraining = new TranslatorTraining(new WordsData(new Dictionary<string, string>()
            {
                {"black", "черный"},
                {"red", "красный"}
            }));
            // Assert
            Assert.AreEqual(sprintTraining.CountOfWordsToCheck, 10);
        }
    }
}