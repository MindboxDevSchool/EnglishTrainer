using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests {
    public class WordsStorageTests {
        [Test]
        public void WordsStorageTest() {
            //arrange
            const int howMuchWordsGenerate = 2;
            var inputWords = new Words(new List<Word> {
                new Word( "компенсировать", "indemnify"),
                new Word( "лотерея", "sweepstakes"),
                new Word( "боковая опорамоста", "abutment")
            });
            var wordsStorage = new WordsStorage(inputWords);
            var expectedWords = new Words(new List<Word> {
                new Word( "компенсировать", "indemnify"),
                new Word( "лотерея", "sweepstakes"),
            });

            //act
            var generateWordsForTraining = wordsStorage.GenerateUnlearntWords(howMuchWordsGenerate);

            //assert
            Assert.That(expectedWords, Is.EquivalentTo(generateWordsForTraining));
        }

        [Test]
        public void TryingCreateWordsStorageTestWrongParam() {
            //arrange
            var wordsStorage = new WordsStorage(new Words(
                new List<Word> {
                    new Word( "компенсировать", "indemnify"),
                }));

            //act

            //assert
            Assert.Throws<ArgumentException>(() => wordsStorage.GenerateUnlearntWords(-2));
            Assert.Throws<ArgumentException>(() => wordsStorage.GenerateUnlearntWords(0));
        }

        [Test]
        public void TryingCreateWordsStorageWithEmptyCollection() {
            //arrange
            var words = new Words(new List<Word>());

            //act

            //assert
            Assert.Throws<ArgumentException>(() => {
                var _ = new WordsStorage(words);
            });
        }

        [Test]
         public void UpdateStorageWithSameWordsListUntilLearnt() {
             //arrange
             //storage from three entries 
             const int howMuchWordsGenerate = 3;
             var wordsStorage = new WordsStorage(
                 new Words(
                     new List<Word> {
                         new Word( "компенсировать", "indemnify"),
                         new Word( "лотерея", "sweepstakes"),
                         new Word( "боковая опорамоста", "abutment")
                     })
             );
        
             //word for training 
             var trainingResult = new List<ResultForUpdateStorage> {
                 new ResultForUpdateStorage(new Word( "компенсировать", "indemnify"), true), 
                 new ResultForUpdateStorage(new Word( "боковая опорамоста", "abutment"), true)
             };
             
             var expectedLeftWordsInStorage = new List<Word> {
                 new Word( "лотерея", "sweepstakes"),
             };
        
             //act
             //update trice 
             const int updateTimesUntilLearn = 3;
             for (var i = 0; i < updateTimesUntilLearn; i++) {
                 wordsStorage.UpdateProgress(trainingResult);
             }
        
             //only 1 unlearned should entry left - new Value("sweepstakes", "лотерея"),
             var generatedWordsForTraining = wordsStorage.GenerateUnlearntWords(howMuchWordsGenerate);
        
             //assert
             Assert.That(expectedLeftWordsInStorage, Is.EquivalentTo(generatedWordsForTraining));
         }
    }
}