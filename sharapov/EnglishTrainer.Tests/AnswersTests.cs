using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishTrainer.Tests {
    public class AnswersTests {

        //[2] Do i have to test boilerplate GetEnumerator()?
        
        [Test]
        public void CountTest() {
            //arrange
            var answers = new UserAnswers<bool>(new List<bool>{true, false});
            var expectedCount = 2;
            //act
            var count = answers.Count();
            //assert
            Assert.AreEqual(count, expectedCount);
        }
    }
}