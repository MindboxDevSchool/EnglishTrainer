using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class QuestionTests
    {
        Word word = new Word("fly", "муха");

        [Test]
        public void ValidateUserInput_InputAndWordAreEqual()
        {
            bool isEqual = Question.ValidateUserInput("Муха", word);
            
            Assert.AreEqual(true,isEqual);
        }
        [Test]
        public void SetQuestionResult_WordIsLearned()
        {
            word.IncreaseTimesGuessedCorrectly();
            word.IncreaseTimesGuessedCorrectly();
            
            Question question = new Question();
            question.SetQuestionResult("Муха", word);
            bool isLearned = word.GetWordIsLearnedStatus();
            
            Assert.AreEqual(true,isLearned);
        }
    }
}