using System.Collections.Generic;
using LanguageTrainer.app;
using LanguageTrainer.model;
using NUnit.Framework;

namespace LanguageTrainerTests
{
    [TestFixture]
    public class EnglishTrainerTests
    {
        [Test]
        public void Practice_SprintExercise()
        {
            // Arrange
            EnglishTrainer trainer = new EnglishTrainer();
            
            // Act
            trainer.Practice<SprintExercise>();
            
            // Assert
            Assert.Pass();
        }
        
        [Test]
        public void Practice_TranslationExercise()
        {
            // Arrange
            EnglishTrainer trainer = new EnglishTrainer();
            
            // Act
            trainer.Practice<TranslationExercise>();
            
            // Assert
            Assert.Pass();
        }
    }
}
