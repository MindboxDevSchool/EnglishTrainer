using System.Collections.Generic;

namespace EnglishTrainer.Domain
{
    public interface IWordsRepository
    {
        public Dictionary<string, string> WordsToTrain { get; }
        public int WordsPerTraining { set; }
        public List<string> ShuffledWordTranslations { get; }
        public void RemoveLearnedWords(IEnumerable<string> correctlyAnsweredWords);
        public void SelectWordsForTrainingSession();
        public void ShuffleTranslations();
    }
}