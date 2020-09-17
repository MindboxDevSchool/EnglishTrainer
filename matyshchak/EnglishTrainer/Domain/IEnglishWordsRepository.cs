using System.Collections.Generic;

namespace EnglishTrainer
{
    public interface IEnglishWordsRepository
    {
        public IEnumerable<EnglishWord> GetRandomNotLearnedWords(int numberOfWords);
        public void UpdateWordsStatus(IEnumerable<EnglishWord> words);
    }
}