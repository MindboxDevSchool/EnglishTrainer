using System;
using System.Collections.Generic;

namespace EnglishTrainer
{
    public class WordsPairs
    {
        private static List<WordsPair> _wordsPairs;

        public WordsPairs(List<WordsPair> wordsPairs)
        {
            _wordsPairs = wordsPairs;
        }

        public static int GetNumberOfWordsPairs()
        {
            return _wordsPairs.Count;
        }

        public static WordsPair GetWordsPair(int indexOfPair)
        {
            return _wordsPairs[indexOfPair];
        }

        public static WordsPair GetRandomWordsPair(bool isPairCorrect)
        {
            var random = new Random();
            if (isPairCorrect)
                return _wordsPairs[random.Next(GetNumberOfWordsPairs())];
            else
            {
                var generatedIndexesAreTheSame = true;
                var englishWordIndex = new int();
                var russianWordIndex = new int();
                while (generatedIndexesAreTheSame)
                {
                    englishWordIndex = random.Next(GetNumberOfWordsPairs());
                    russianWordIndex = random.Next(GetNumberOfWordsPairs());
                    if (englishWordIndex != russianWordIndex)
                        generatedIndexesAreTheSame = false;
                }

                return CreateWordsPairWithIndexes(englishWordIndex, russianWordIndex, false);
            }
        }
        
        public static WordsPair CreateWordsPairWithIndexes(int englishWordIndex, int russianWordIndex, bool isPairCorrect)
        {
            string englishWord = WordsPairs.GetWordsPair(englishWordIndex)._englishWord;
            string russianWord = WordsPairs.GetWordsPair(russianWordIndex)._russianWord;
            WordsPair wordsPair = new WordsPair(englishWord, russianWord, isPairCorrect);
            return wordsPair;
        }

        public static WordsPair GenerateWordsPairPossiblyRandom()
        {
            var random = new Random();
            bool correctUserAnswer;
            var isWordPairCorrect = random.Next(2) > 0;
            var currentWordsPair = WordsPairs.GetRandomWordsPair(isWordPairCorrect);
            return currentWordsPair;
        }
    }
}