using System.Collections.Generic;

namespace EnglishTrainer.TranslateWordTraining {
    public class EnglishWords {
        private readonly List<string> engWords = new List<string>();

        public EnglishWords(Words trainingWords) {
            foreach (var word in trainingWords) {
                engWords.Add(word.EngDefinition);
            }
        }
    }
}