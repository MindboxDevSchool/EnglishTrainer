using System;
using System.Collections.Generic;

namespace EnglishTrainer.App
{
    public class WordsContainer
    {
        // as we don't have any database for now, we have to use the most basic (and most barbarous) way
        private readonly List<WordPair> _wordsStorage;
        private readonly Random _random;
        private readonly int _range;
        
        public WordsContainer(List<WordPair> wordsStorage)
        {
            _wordsStorage = wordsStorage;
            _random = new Random();
            _range = wordsStorage.Count;
        }

        public WordPair[] GetRandomSelect(int length)
        {
            WordPair[] pairs = new WordPair[length];
            for (int i = 0; i < length; i++)
            {
                bool notFound;
                do
                {
                    int index = _random.Next(0, _range);
                    pairs[i] = _wordsStorage[index];
                    notFound = pairs[i].isLearned;
                } while (notFound);
            }
            return pairs;
        }

        public string GetRandomTranslate(WordPair initial)
        {
            bool isAccurate = _random.Next(1, 3) == 1;
            if (isAccurate)
            {
                return initial.NativeLanguageWord;
            }

            return GetInaccurateTranslate(initial);
        }

        private string GetInaccurateTranslate(WordPair initial)
        {
            bool notFound;
            WordPair wordPair;
            do
            {
                int index = _random.Next(0, _range);
                wordPair = _wordsStorage[index];
                notFound = wordPair.NativeLanguageWord == initial.NativeLanguageWord;
            } while (notFound);

            return wordPair.NativeLanguageWord;
        }
        
        public void AdjustMatchedWords(WordPair[] pairs, bool[] isCorrect)
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                if (isCorrect[i])
                {
                    int index = _wordsStorage.FindIndex(x => x.Equals(pairs[i]));
                    _wordsStorage[index].MatchedCorrectly();
                }
            }
        }
        
        public void AdjustTranslatedWords(WordPair[] pairs, bool[] isCorrect)
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                if (isCorrect[i])
                {
                    int index = _wordsStorage.FindIndex(x => x.Equals(pairs[i]));
                    _wordsStorage[index].TranslatedCorrectly();
                }
            }
        }
    }
}