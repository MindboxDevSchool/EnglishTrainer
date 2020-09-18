using System;
using System.Collections.Generic;
using System.IO;

namespace EnglishTrainer.Infrastructure
{
    public class CsvWordsLoader : IWordsLoader
    {
        private Dictionary<string, string> Words { get; }
        public Dictionary<string, string> LoadWords => Words;
        public CsvWordsLoader(string filename)
        {
            if (!File.Exists(filename)) {
                throw new FileNotFoundException("The file does not exist.");
            }
            using var fileReader = new StreamReader(filename);
            var words = new Dictionary<string, string>();
            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();
                var parsedWords = line?.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (parsedWords?.Length == 2)
                {
                    words.Add(parsedWords[0], parsedWords[1]);
                }
            }
            Words = words;
        }
    }
}