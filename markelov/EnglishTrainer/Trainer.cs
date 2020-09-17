using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EnglishTrainer
{
    public static class Trainer
    {
        private static Dictionary<string, Word> Dictionary { get; set; }

        public static void PopulateDictionary(Dictionary<string, Word> dictionary)
        {
            Dictionary = dictionary;
        }

        public static Dictionary<string, Word> GetDictionary()
        {
            return Dictionary;
        }
        
        public static Dictionary<string, Word> UpdateDictionaryWithResults(Result result)
        {
            foreach (QuestionResult questionResult in result.GetQuestionResults())
            {
                Word word = questionResult.GetWordOutOfWordResult();
                string wordName = word.GetWordVocable();
                Dictionary[wordName] = word;
            }

            return Dictionary;
        }
    }
}