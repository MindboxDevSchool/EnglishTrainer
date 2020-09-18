using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer {
    public class WordsStorage {
        private const int WordUnlearnedInitValue = 0;
        private const int WordLearnedValue = 3;
        
        private readonly Dictionary<Word, int> _storage;

        public WordsStorage(Words words) {
            if (words.IsEmpty()) {
                throw new ArgumentException($"Trying create storage from empty collection {nameof(words)}");
            }
            _storage = new Dictionary<Word, int>();
            foreach (Word word in words) {
                _storage.Add(word, WordUnlearnedInitValue);
            }
        }
        
        public void UpdateProgress(IEnumerable<ResultForUpdateStorage> wordForUpdateProgress) {
            if (wordForUpdateProgress == null) {
                throw new ArgumentNullException(nameof(wordForUpdateProgress));
            }
            
            foreach (var wordInfo in wordForUpdateProgress) {
                if (wordInfo.IsAnswerWasRight) {
                    _storage[wordInfo.Word] += 1;
                }
            }
        }
        
       
        public Words GenerateUnlearntWords(int trainingNumberWordsForTraining) {
            if (trainingNumberWordsForTraining <= 0) {
                throw new ArgumentException($"{nameof(trainingNumberWordsForTraining)} zero or less than zero");
            }
            var unlearntWordsList = _storage.
                Where(x => x.Value < WordLearnedValue).
                Select(x => new Word(x.Key.RusDefinition, x.Key.EngDefinition)).
                Take(trainingNumberWordsForTraining).
                ToList();  //for shuffle collection   OrderBy((elem => Guid.NewGuid()))
            return new Words(unlearntWordsList);
        }

        public Word GetRandomWord() {
            var rand = new Random();
            return _storage.ElementAt(rand.Next(0, _storage.Count)).Key;
        }
    }
}