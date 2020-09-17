using System;
using System.Collections.Generic;
using System.IO;

namespace EnglishTrainer
{
    public class DataService
    {
        public List<VocabularyWord> LoadWordsFromFile(string path)
        {
            List<VocabularyWord> loadedWords = new List<VocabularyWord>();

            using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                string[] line = reader.ReadLine()?.Split(";");

                if (line != null)
                    loadedWords.Add(new VocabularyWord(line[0], line[1]));
            }
            
            if (loadedWords.Count == 0)
                throw new ArgumentNullException("File doesn't contain any words.");

            return loadedWords;
        }
    }
}