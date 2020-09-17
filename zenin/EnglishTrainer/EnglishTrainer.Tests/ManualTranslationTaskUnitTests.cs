using System.Data;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class ManualTranslationTaskUnitTests
    {
        [Test]
        public void SetOfTwoWordsAndTranslations_CheckAnswers_OneCorrectTranslation()
        {
            var task = new ManualTranslationTask();
            var setOfWords = Vocabulary.CreateEmptyDataTable();
            setOfWords.Rows.Add("one", "один");
            setOfWords.Rows.Add("two", "два");
            string[] answers = {"один", "три"};

            var correctTranslations = task.CheckAnswers(setOfWords, answers);
            
            Assert.AreEqual(new string[] {"one"}, correctTranslations);
        }

        [Test]
        public void VocabularyFromFileWithWords_CountNonRepeatedWordsVocabulary_AllWordsInVocabularyNonRepeated()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new ManualTranslationTask();

            var countOfNonRepeatedWords = task.CountNonRepeatedWordsVocabulary(vocabulary);
            
            Assert.AreEqual(vocabulary.Length, countOfNonRepeatedWords);
        }

        [Test]
        public void VocabularyFromFileWithWords_CheckIsEnoughWordsInVocabulary_Enough()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new ManualTranslationTask();

            var isEnoughWords = task.CheckIsEnoughWordsInVocabulary(vocabulary);
            
            Assert.AreEqual(true, isEnoughWords);
        }
        
        [Test]
        public void VocabularyFromFileWithWords_CountNonRepeatedWordsVocabulary_AllWordsInVocabularyRepeated()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new ManualTranslationTask();
            for (int i = 0; i < vocabulary.Length; i++)
                vocabulary.Words.Rows[i].SetField("repeated", 4);

            var countOfNonRepeatedWords = task.CountNonRepeatedWordsVocabulary(vocabulary);
            
            Assert.AreEqual(0, countOfNonRepeatedWords);
        }
        
        [Test]
        public void VocabularyFromFileWithWords_CheckIsEnoughWordsInVocabulary_NotEnough()
        {
            var vocabulary = new Vocabulary("words.csv");
            var task = new ManualTranslationTask();
            for (int i = 0; i < vocabulary.Length; i++)
                vocabulary.Words.Rows[i].SetField("repeated", 4);

            var isEnoughWords = task.CheckIsEnoughWordsInVocabulary(vocabulary);
            
            Assert.AreEqual(false, isEnoughWords);
        }
    }
}