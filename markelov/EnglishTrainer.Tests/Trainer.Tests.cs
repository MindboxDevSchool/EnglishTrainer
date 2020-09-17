using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class TrainerTests
    {

        [Test]
        public void UpdateDictionaryWithResults_GoodData()
        {
            Word word = new Word("fly", "летать");
            Dictionary<string, Word> dictionary = new Dictionary<string, Word>
            {
                { word.GetWordVocable(), word },
                { "walk", new Word("walk", "идти") },
                { "talk", new Word("talk", "говорить") }
            };
            word.IncreaseTimesGuessedCorrectly();
            QuestionResult questionResult = new QuestionResult(word, true);
            List<QuestionResult> questionResults = new List<QuestionResult>
            {
                questionResult
            };
            Result result = new Result(questionResults);
            Trainer.PopulateDictionary(dictionary);

            dictionary = Trainer.UpdateDictionaryWithResults(result);
            int timesGuessed = dictionary["fly"].GetTimesGuessedCorrectly();

            Assert.AreEqual(1,timesGuessed);
        }
    }
}