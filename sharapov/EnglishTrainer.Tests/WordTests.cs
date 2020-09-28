using System;
using NUnit.Framework;

namespace EnglishTrainer.Tests {
    public class WordTests {
        
        //[1] How test Equals GetHashCode
        
        [Test]
        public void EqualWords() {
            //arrange
            var word1 = new Word("кроватка", "crib");
            Word word2 = new Word("кроватка", "crib");

            //act
            bool word1IsEqualWord2 = word1.Equals(word2);

            //assert 
            Assert.IsTrue(word1IsEqualWord2);
        }

        [Test]
        public void DifferentRusDefinition() {
            //arrange
            Word word1 = new Word("палатка", "crib");
            Word word2 = new Word("кроватка", "crib");

            //act
            bool word1IsEqualWord2 = word1.Equals(word2);

            //assert 
            Assert.IsFalse(word1IsEqualWord2);
        }

        [Test]
        public void DifferentEngDefinition() {
            //arrange
            Word word1 = new Word("кроватка", "crip");
            Word word2 = new Word("кроватка", "crib");

            //act
            bool word1IsEqualWord2 = word1.Equals(word2);

            //assert 
            Assert.IsFalse(word1IsEqualWord2);
        }

        [Test]
        public void DifferentRusAndEngDefinition() {
            //arrange
            Word word1 = new Word("палатка", "tent");
            Word word2 = new Word("кроватка", "crib");

            //act
            bool word1IsEqualWord2 = word1.Equals(word2);

            //assert 
            Assert.IsFalse(word1IsEqualWord2);
        }

        [Test]
        public void PassNullOrEmptyString() {
            //arrange

            //act
            
            //assert 
            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word(null, null);
                }
            );
            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word(null, "tent");
                }
            );
            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word("палатка", null);
                }
            );

            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word("", "");
                }
            );
            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word("", "tent");
                }
            );
            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word("палатка", "");
                }
            );

            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word(null, "");
                }
            );
            Assert.Throws<ArgumentException>(() => {
                    var _ = new Word("", null);
                }
            );
        }
    }
}