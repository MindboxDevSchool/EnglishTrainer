using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class VocabularyWordTests
    {
        [Test]
        public void IncreaseStudyProgress_3CallsForOneWord()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("yellow", "желтый")
            });

            //act
            for (int i = 0; i < 3; i++)
            {
                vocabulary.Words[0].IncreaseStudyProgress();
            }

            //assert
            Assert.IsTrue(vocabulary.Words[0].IsStudied);
        }
    }
}