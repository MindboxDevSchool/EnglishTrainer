using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests.SprintTraining {
    public class SprintTrainingTests {
        [Test]
        public void SprintTrainingTest() {
            //arrange
            const int howMuchWordsGenerateForTraining = 2;
            const double rightAndWrongWordsRatio = 0.5d;
            var wordsWithCorrectDefinitions = new Words(new List<Word> {
                new Word( "компенсировать", "indemnify"),
                new Word( "лотерея", "sweepstakes"),
                new Word( "боковая опора моста", "abutment"),
                new Word( "прижаться носом", "nuzzle"),
            });
            var wordsStorage = new WordsStorage(wordsWithCorrectDefinitions);


            //act
            var training = new EnglishTrainer.SprintTraining.SprintTraining(wordsStorage, howMuchWordsGenerateForTraining, rightAndWrongWordsRatio );
            var userAnswers = new UserAnswers<bool>(
                new List<bool> {
                    false,
                    true
                });
            var trainResults = training.ReportAboutTrainingResult(userAnswers);
            var trainingWords = training.GetTrainingWords();
            //assert
            Assert.AreEqual(2, trainResults.Count);
            Assert.AreEqual(2, trainResults.AmountHit);
            Assert.AreEqual(0, trainResults.AmountMiss);
        }
    }
}