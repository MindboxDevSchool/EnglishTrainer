using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class VocabularyTests
    {
        [Test]
        public void IsContains_3WordsFromVocabulary()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("word", "слово"),
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка"),
                new VocabularyWord("car", "машина"),
                new VocabularyWord("apple", "яблоко")
            });
            
            List<Word> words = new List<Word>()
            {
                new Word("word", "слово"),
                new VocabularyWord("cat", "кошка"),
                new VocabularyWord("apple", "яблоко")
            };
            
            //act
            bool isContains = vocabulary.IsContains(words);

            //assert
            Assert.AreEqual(true, isContains);
        }
        
        [Test]
        public void IsContains_2WordsNotFromVocabulary()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("word", "слово"),
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка"),
                new VocabularyWord("car", "машина"),
                new VocabularyWord("apple", "яблоко")
            });
            
            List<Word> words = new List<Word>()
            {
                new VocabularyWord("word", "слово"),
                new VocabularyWord("green", "зеленый"),
                new VocabularyWord("red", "красный")
            };
            
            //act
            bool isContains = vocabulary.IsContains(words);

            //assert
            Assert.AreEqual(false, isContains);
        }
        
        [Test]
        public void GetNotStudiedWords_3NotStudiedWordsInVocabulary()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("yellow", "желтый"),
                new VocabularyWord("green", "зеленый"),
                new VocabularyWord("red", "красный"),
                new VocabularyWord("pink", "розовый")
            });

            //act
            for (int i = 0; i < 3; i++)
            {
                vocabulary.Words[0].IncreaseStudyProgress();
            }

            List<VocabularyWord> notStudiedWords = vocabulary.GetNotStudiedWords();

            //assert
            Assert.AreEqual(3, notStudiedWords.Count);
        }
    }
}