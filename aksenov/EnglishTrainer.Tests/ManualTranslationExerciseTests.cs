using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class ManualTranslationExerciseTests
    {
        [Test]
        public void GetExerciseData_CorrectOutputArraySize()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка")
            });

            ManualTranslationExercise exercise = new ManualTranslationExercise(vocabulary);

            //act
            string[] words = exercise.GetExerciseData();

            //assert
            Assert.AreEqual(10, words.Length);
        }
    }
}