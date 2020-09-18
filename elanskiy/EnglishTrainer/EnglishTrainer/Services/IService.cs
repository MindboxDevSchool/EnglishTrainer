using System.Collections.Generic;
using EnglishTrainer.Vocabularies;

namespace EnglishTrainer.Services
{
    public interface IService
    {
        public List<Word> GetWords();
        public void UpdateVocabulary(IEnumerable<Word> words);
    }
}