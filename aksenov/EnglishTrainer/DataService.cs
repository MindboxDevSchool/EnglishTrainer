using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnglishTrainer
{
    public class DataService
    {
        public List<VocabularyWord> LoadWordsFromFile(string path)
        {
            List<VocabularyWord> loadedWords = new List<VocabularyWord>();

            using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(";");

                    if (line != null && line.Length >= 2)
                        loadedWords.Add(new VocabularyWord(line[0], line[1]));
                }
            }
            
            if (loadedWords.Count == 0)
                throw new ArgumentNullException("File doesn't contain any words.");

            return loadedWords;
        }
    }
}