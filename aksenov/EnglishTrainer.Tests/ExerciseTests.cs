using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests
{
    public class ExerciseTests
    {
        [Test]
        public void CheckSolution_4WordsInInput_TwoAreCorrect()
        {
            //arrange
            Vocabulary vocabulary = new Vocabulary(new List<VocabularyWord>()
            {
                new VocabularyWord("dog", "собака"),
                new VocabularyWord("cat", "кошка"),
                new VocabularyWord("car", "машина"),
                new VocabularyWord("apple", "яблоко"),
                new VocabularyWord("yellow", "желтый"),
                new VocabularyWord("green", "зеленый"),
                new VocabularyWord("red", "красный"),
                new VocabularyWord("pink", "розовый")
            });
            
            List<Word> words = new List<Word>()
            {
                new Word("dog", "кошка"),
                new Word("apple", "яблоко"),
                new VocabularyWord("yellow", "красный"),
                new VocabularyWord("green", "зеленый")
            };
            
            SprintExercise exercise = new SprintExercise(vocabulary);

            //act
            ExerciseResult exerciseResult = exercise.CheckSolution(words);

            //assert
            Assert.AreEqual(2, exerciseResult.RightAnswersNumber);
            Assert.AreEqual(2, exerciseResult.WrongAnswersNumber);
        }
    }
}