using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class WordTests
    {
        Word word = new Word("fly", "муха");

        [Test]
        public void IncreaseTimesGuessedCorrectly_Word_IncreasedByOne()
        {
            word.IncreaseTimesGuessedCorrectly();
            int timesGuessedCorrectly = word.GetTimesGuessedCorrectly();
            
            Assert.AreEqual(1, timesGuessedCorrectly);
        }
        [Test]
        public void SetWordAsLearned_Word()
        {
            word.SetWordAsLearned();
            bool wordIsLearned = word.GetWordIsLearnedStatus();
            
            Assert.IsTrue(wordIsLearned);
        }
    }
}