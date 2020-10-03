using EnglishTrainer;
using NUnit.Framework;

namespace Sprint.Tests
{
    public class Trainer_Tests
    {
        [Test]
        public void GenerateWordsPairs_SprintMode()
        {
            // arrange
            WordsPairs wordsPairs = new WordsPairs(Input.GetWordsPairs());
            int mode = 0;
            int numberOfWordsForSprint = 15;
            int numberOfWordsForManualTranslation = 10;
            // act
            var result = Trainer.GenerateWordsPairs
                (mode, numberOfWordsForSprint, numberOfWordsForManualTranslation)
                .Length;
            // assert
            Assert.AreEqual(15, result);
        }
        
        [Test]
        public void GenerateWordsPairs_ManualTranslationMode()
        {
            // arrange
            WordsPairs wordsPairs = new WordsPairs(Input.GetWordsPairs());
            int mode = 1;
            int numberOfWordsForSprint = 15;
            int numberOfWordsForManualTranslation = 10;
            // act
            var result = Trainer.GenerateWordsPairs
                    (mode, numberOfWordsForSprint, numberOfWordsForManualTranslation)
                .Length;
            // assert
            Assert.AreEqual(10, result);
        }
    }
}