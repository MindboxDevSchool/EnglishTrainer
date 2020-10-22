using System.Collections.Generic;
using NUnit.Framework;

namespace EnglishLearn.Tests
{
    public class LearningStatisticsTests
    {
        [Test]
        public void IsWordLearned_WordLearned3Times_ReturnsTrue()
        {
            // Arrange
            var learningStatistics = new LearningStatistics();
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            // Act
            var isWordLearned = learningStatistics.IsWordLearned("kek");
            // Assert
            Assert.True(isWordLearned);
        }
        
        [Test]
        public void IsWordLearned_WordLearned2Times_ReturnsFalse()
        {
            // Arrange
            var learningStatistics = new LearningStatistics();
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            // Act
            var isWordLearned = learningStatistics.IsWordLearned("kek");
            // Assert
            Assert.False(isWordLearned);
        }
        
        [Test]
        public void IsWordLearned_UnknownWord_ReturnsFalse()
        {
            // Arrange
            var learningStatistics = new LearningStatistics();
            // Act
            var isWordLearned = learningStatistics.IsWordLearned("kek");
            // Assert
            Assert.False(isWordLearned);
        }
        
        [Test]
        public void IncreaseLearningStatisticsForWord_IncreaseByOne_StatisticsIncreasedByOne()
        {
            // Arrange
            var learningStatistics = new LearningStatistics();
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            // Act
            var learningStatisticsForWord = learningStatistics._learningStatistics["kek"];
            // Assert
            Assert.AreEqual(1, learningStatisticsForWord);
        }

        [Test]
        public void GetLearningStatistics_StatisticsNotEmpty_ReturnsStatistics()
        {
            // Arrange
            var gettedLearningStatisticsOriginal = new Dictionary<string, int>()
            {
                {"kek", 1}
            };
            
            var learningStatistics = new LearningStatistics();
            learningStatistics.IncreaseLearningStatisticsForWord("kek");
            // Act
            var gettedLearningStatistics = learningStatistics.GetLearningStatistics();
            // Assert
            Assert.AreEqual(gettedLearningStatisticsOriginal, gettedLearningStatistics);
        }
    }
}