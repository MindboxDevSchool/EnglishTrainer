using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer
{
    public class Vocabulary
    {
        public List<VocabularyWord> Words { get; private set; }

        public Vocabulary(List<VocabularyWord> words)
        {
            Words = words;
        }

        public bool IsContains(List<Word> words)
        {
            foreach (var word in words)
            {
                if (Words.FirstOrDefault(w => w.Spelling == word.Spelling) == null)
                    return false;
            }

            return true;
        }

        private bool IsContainsNotStudied()
        {
            return Words.FirstOrDefault(w => w.Status == VocabularyWordStatus.NotStudied) != null;
        }

        public List<VocabularyWord> GetNotStudiedWords()
        {
            if (!IsContainsNotStudied())
                throw new InvalidOperationException();
            
            return Words.Where(w => w.Status == VocabularyWordStatus.NotStudied).ToList();
        }
    }
}