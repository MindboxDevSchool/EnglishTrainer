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

        public bool DoesContain(List<Word> words)
        {
            foreach (var word in words)
            {
                if (Words.FirstOrDefault(w => w.Base.Spelling == word.Spelling) == null)
                    return false;
            }

            return true;
        }

        private bool DoesContainNotStudied()
        {
            return Words.FirstOrDefault(w => !w.IsStudied) != null;
        }

        public List<VocabularyWord> GetNotStudiedWords()
        {
            if (!DoesContainNotStudied())
                throw new InvalidOperationException("Vocabulary doesn't contain not studied words.");
            
            return Words.Where(w => !w.IsStudied).ToList();
        }
    }
}