using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class SprintExerciseTests
    {
        [Test]
        public void GetExerciseData_CorrectOutputArraySize()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("dog", "собака")
            });

            SprintExercise exercise = new SprintExercise(vocabulary);

            //act
            Word[] words = exercise.GetExerciseData();

            //assert
            Assert.AreEqual(15, words.Length);
        }
    }
}