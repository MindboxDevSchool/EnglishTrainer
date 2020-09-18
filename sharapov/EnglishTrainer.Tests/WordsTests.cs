using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests {
    public class WordsTests {
        [Test]
        public void NotEmptyWordsCollection() {
            //arrange
            var words = new Words(new List<Word> {
                new Word( "лотерея", "sweepstakes"),
                new Word( "боковая опорамоста", "abutment")
            });
           
            //act
            var isEmpty = words.IsEmpty();
            
            //assert
            Assert.AreEqual(isEmpty, false);
        }
        
        [Test]
        public void EmptyWordsCollection() {
            //assert
            Assert.Throws<ArgumentException>(() => {
                var _ = new Words(new List<Word>());
            });
        }
        
        [Test]
        public void PassNullCollection() {
            //assert
            Assert.Throws<ArgumentNullException>(() => {
                var _ = new Words(null);
            });
        }
    }
}