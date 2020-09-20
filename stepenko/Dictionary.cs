using System.Collections.Generic;

namespace EN_RUS_Trainer
{
    public class Dictionary
    {
        private static List<WordPair> dictionaryForLearning;

        private static readonly string[] originalWords = CsvDictionaryGenerator.GetOriginalWordsFromCsv();
        private static readonly string[] translatedWords = CsvDictionaryGenerator.GetTranslationOfWordsFromCsv();
        
        private static List<WordPair> GenerateDictionary(string[] originalWords, string[] translatedWords)
        {
            for (var i = 0; i < originalWords.Length; i++)
            {
                var originalWord = originalWords[i];
                var translatedWord = translatedWords[i];
                dictionaryForLearning.Add(new WordPair(originalWord, translatedWord));
            }

            return dictionaryForLearning;
        }

        public static List<WordPair> DictionaryForLearning
        {
            get => dictionaryForLearning;
            set => GenerateDictionary(originalWords, translatedWords);
        }

        public void ClearDictionary()
        {
            DictionaryForLearning.Clear();
        }
    }
}