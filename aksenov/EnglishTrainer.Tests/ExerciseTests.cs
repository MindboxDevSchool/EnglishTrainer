using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class ExerciseTests
    {
        [Test]
        public void CheckExerciseSolution_2WordsInInput_OneIsCorrect()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка"),
                new VocabularyWord("apple", "яблоко")
            });
            
            List<Word> words = new List<Word>()
            {
                new Word("dog", "кошка"),
                new Word("apple", "яблоко")
            };
            
            SprintExercise exercise = new SprintExercise(vocabulary);

            //act
            ExerciseResult exerciseResult = exercise.CheckExerciseSolution(words);

            //assert
            Assert.AreEqual(1, exerciseResult.RightAnswersNumber);
            Assert.AreEqual(1, exerciseResult.WrongAnswersNumber);
        }
    }
}