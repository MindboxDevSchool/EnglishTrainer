using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearn
{
    public class WordsData
    {
        // Must be private. Public just for tests
        public readonly Dictionary<string, string> _wordsData;

        public WordsData(Dictionary<string, string> wordsData)
        {
            if (wordsData.Count > 0)
            {
                _wordsData = wordsData;
            }
            else
            {
                throw new EnglishLearnException("Word dictionary is empty!");
            }
        }

        public string GetEnglishTranslateOfRussianWord(string russianWord)
        {
            foreach (var (englishDictionaryWord, russianDictionaryWord) in _wordsData)
            {
                if (russianWord == russianDictionaryWord)
                {
                    return englishDictionaryWord;
                }
            }
            throw new EnglishLearnException(String.Format("Word '{0}' not found in dictionary words!", russianWord));
        }

        public KeyValuePair<string, string> GetRandomWordPair()
        {
            var random = new Random();
            return _wordsData.ElementAt(random.Next(_wordsData.Count));
        }

        public IReadOnlyDictionary<string, string> GetWordsData()
        {
            return _wordsData;
        }
    }
}