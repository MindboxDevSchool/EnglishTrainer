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
            Trainer trainer = Trainers.EnglishTrainer;
            object TaskPresenter(object task) => true;

            // Act
            trainer.Practice<SprintExercise>(TaskPresenter);
            
            // Assert
            Assert.Pass();
        }
        
        [Test]
        public void Practice_TranslationExercise()
        {
            // Arrange
            Trainer trainer = Trainers.EnglishTrainer;
            object TaskPresenter(object task) => "Не ставьте два...";
            
            // Act
            trainer.Practice<TranslationExercise>(TaskPresenter);
            
            // Assert
            Assert.Pass();
        }
    }
}
