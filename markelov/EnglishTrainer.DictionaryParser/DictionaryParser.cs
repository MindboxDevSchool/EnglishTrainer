using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnglishTrainer.DictionaryParser
{
    public static class DictionaryParser
    {
        public static string FilePath = @"..\..\..\..\EnglishTrainer.DictionaryParser\dict.csv";
        public static Dictionary<string, Word> ParseDictionary(string filePath)
        {
            if (CheckIfFileIsValid(filePath) != true)
            {
                return null;
            }
            Dictionary<string, Word> parsedDictionary = new Dictionary<string, Word>();
            
            StreamReader reader = new StreamReader(filePath, Encoding.UTF8);
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] wordFields = line.Split(';');

                try
                {
                    string wordName = wordFields[0];
                    string wordTranslation = wordFields[1];
                   
                    Word newWord = new Word(wordName, 
                        wordTranslation);
                    
                    parsedDictionary.Add(wordName, newWord);
                }
                catch
                {
                    return null;
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return parsedDictionary;
        }
        public static bool CheckIfFileIsValid(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            if (new FileInfo(filePath).Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}