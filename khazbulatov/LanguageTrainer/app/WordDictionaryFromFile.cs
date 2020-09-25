using System;
using System.Collections.Generic;
using System.IO;
using LanguageTrainer.model;

namespace LanguageTrainer.app
{
    public class WordDictionaryFromFile : WordDictionary
    {
        private readonly string _filename;
        public WordDictionaryFromFile(string filename)
        {
            _filename = filename;
        }

        public override Dictionary<string, string> Load(Language fromLanguage, Language toLanguage)
        {
            using StreamReader reader = new StreamReader(_filename);
            string[] header = reader.ReadLine().Split(',');
            int from = -1, to = -1;
            for (int i = 0; i < header.Length; ++i)
            {
                if (header[i] == fromLanguage.Name) from = i;
                if (header[i] == toLanguage.Name) to = i;
            }
            if (from == -1 || to == -1) throw new ApplicationException();
            
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            while (!reader.EndOfStream)
            {
                string[] row = reader.ReadLine().Split(',');
                dictionary[row[from]] = row[to];
            }
            return dictionary;
        }
    }
}
