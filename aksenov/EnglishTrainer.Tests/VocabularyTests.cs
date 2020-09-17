using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class VocabularyTests
    {
        [Test]
        public void DoesContain_2WordsInInput_BothFromVocabulary()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("word", "слово"),
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка")
            });
            
            List<Word> words = new List<Word>()
            {
                new Word("word", "слово"),
                new Word("cat", "кошка")
            };
            
            //act
            bool doesContain = vocabulary.DoesContain(words);

            //assert
            Assert.IsTrue(doesContain);
        }
        
        [Test]
        public void DoesContain_2WordsInInput_1NotFromVocabulary()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("word", "слово"),
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка")
            });
            
            List<Word> words = new List<Word>()
            {
                new Word("word", "слово"),
                new Word("green", "зеленый")
            };
            
            //act
            bool doesContain = vocabulary.DoesContain(words);

            //assert
            Assert.IsFalse(doesContain);
        }
        
        [Test]
        public void GetNotStudiedWords_2NotStudiedWordsInVocabulary_CorrectOutputListSize()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("yellow", "желтый"),
                new VocabularyWord("green", "зеленый")
            });

            //act
            List<VocabularyWord> notStudiedWords = vocabulary.GetNotStudiedWords();

            //assert
            Assert.AreEqual(2, notStudiedWords.Count);
        }
    }
}