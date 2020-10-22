using System.Collections.Generic;
using System.IO;

namespace EnglishLearn
{
    public static class WordsDataFactory
    {
        public static WordsData MakeWordsDataFromFile(string pathToFile)
        {
            var wordsData = new Dictionary<string, string>();
            if (File.Exists(pathToFile))
            {
                using var streamReader = new StreamReader(pathToFile);
                string readiedLine;
                while ((readiedLine = streamReader.ReadLine()) != null)
                {
                    var parsedLineList = new List<string>(readiedLine.Split(';'));
                    if (parsedLineList.Count == 2)
                    {
                        wordsData.Add(parsedLineList[0].Trim(), parsedLineList[1].Trim());
                    }
                    else
                    {
                        throw new EnglishLearnException("Bad words dictionary file!");
                    }
                }
                return new WordsData(wordsData);
            }
            else
            {
                throw new EnglishLearnException("Dictionary file not found!");
            }
        }
    }
}