using System.Collections.Generic;

namespace EnglishLearn
{
    public class LearningStatistics
    {
        // Must be private
        public readonly Dictionary<string, int> _learningStatistics;

        public LearningStatistics()
        {
            _learningStatistics = new Dictionary<string, int>();
        }

        public bool IsWordLearned(string englishWord)
        {
            if (_learningStatistics.ContainsKey(englishWord))
            {
                return _learningStatistics[englishWord] >= 3;
            }

            return false;
        }

        public void IncreaseLearningStatisticsForWord(string englishWord)
        {
            if (_learningStatistics.ContainsKey(englishWord))
            {
                _learningStatistics[englishWord]++;
            }
            else
            {
                _learningStatistics.Add(englishWord, 1);
            }
        }
        
        public IReadOnlyDictionary<string, int> GetLearningStatistics()
        {
            return _learningStatistics;
        }
    }
}