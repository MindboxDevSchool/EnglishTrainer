using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileHelpers;

namespace EnglishTrainer
{
    public static class CsvHandler
    {
        private static FileHelperEngine<WordInDictionary> _engine = new FileHelperEngine<WordInDictionary>();

        public static List<WordInDictionary> LoadFromCsv(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("Specified file doesn't exists");
            }

            return _engine.ReadFile(path).ToList();
        }
        
        public static void WriteToCsv(List<WordInDictionary> list,string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("Specified file doesn't exists");
            }
            _engine.HeaderText = "English,Russian,AmountOfSuccsessfulTranslations";
            _engine.WriteFile(path,list);
        }
    }
}