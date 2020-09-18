using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnglishTrainer.Services;

namespace EnglishTrainer.Vocabularies
{
    public class Vocabulary
    {
        public List<Word> Words { get; }
        private IService Service { get; }
        public Vocabulary(IService service)
        {
            Service = service;
            Words = service.GetWords();
        }
        public void UpdateNumberOfCorrectlyTranslationsByUser(List<string> newLearnedWords)
        {
            foreach (var word in Words.Where(word => newLearnedWords.Contains(word.Value)))
            {
                word.NumberOfCorrectlyTranslationsByUser++;
            }
            Service.UpdateVocabulary(Words);
        }
    }
}