using System.Data;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class SprintTaskUnitTests
    {
        [Test]
        public void SetOfTwoWordsAndTranslations_CheckAnswers_OneCorrectTranslation()
        {
            var task = new SprintTask();
            var setOfWords = Vocabulary.CreateEmptyDataTable();
            setOfWords.Columns.Add("correct", typeof(string));
            setOfWords.Rows.Add("one", "один", "true");
            setOfWords.Rows.Add("two", "два", "true");
            string[] answers = {"false", "true"};

            var correctTranslations = task.CheckAnswers(setOfWords, answers);
            
            Assert.AreEqual(new string[] {"two"}, correctTranslations);
        }

        [Test]
        public void VocabularyFromFileWithWords_CountNonRepeatedWordsVocabulary_AllWordsInVocabularyNonRepeated()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new SprintTask();

            var countOfNonRepeatedWords = task.CountNonRepeatedWordsVocabulary(vocabulary);
            
            Assert.AreEqual(vocabulary.Length, countOfNonRepeatedWords);
        }

        [Test]
        public void VocabularyFromFileWithWords_CheckIsEnoughWordsInVocabulary_Enough()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new SprintTask();

            var isEnoughWords = task.CheckIsEnoughWordsInVocabulary(vocabulary);
            
            Assert.AreEqual(true, isEnoughWords);
        }
        
        [Test]
        public void VocabularyFromFileWithWords_CountNonRepeatedWordsVocabulary_AllWordsInVocabularyRepeated()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new SprintTask();
            for (int i = 0; i < vocabulary.Length; i++)
                vocabulary.Words.Rows[i].SetField("repeated", 4);

            var countOfNonRepeatedWords = task.CountNonRepeatedWordsVocabulary(vocabulary);
            
            Assert.AreEqual(0, countOfNonRepeatedWords);
        }
        
        [Test]
        public void VocabularyFromFileWithWords_CheckIsEnoughWordsInVocabulary_NotEnough()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new SprintTask();
            for (int i = 0; i < vocabulary.Length; i++)
                vocabulary.Words.Rows[i].SetField("repeated", 4);

            var isEnoughWords = task.CheckIsEnoughWordsInVocabulary(vocabulary);
            
            Assert.AreEqual(false, isEnoughWords);
        }
    }
}