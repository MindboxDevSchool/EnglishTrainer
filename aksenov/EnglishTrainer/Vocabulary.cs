using System.Collections.Generic;

namespace EnglishTrainer
{
    public class Vocabulary
    {
        public List<VocabularyWord> Words { get; private set; }

        public Vocabulary(List<VocabularyWord> words)
        {
            Words = words;
        }
    }
}